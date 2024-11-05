using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuickSlot : MonoBehaviour
{
    public GameObject QuickSlotView;
    public Transform SlotPanel;
    public ItemSlot[] Slots;

    private ItemData _selectedItem;    
    private int _equipNum;

    //private PlayerController _controller;
    private int _curEmptySlot;
    private PlayerCondition _condition;


    void Start()
    {
        //_controller = GameManager.Instance.Player.Controller;
        _condition = GameManager.Instance.Player.Condition;
        GameManager.Instance.Player.AddItem += AddItem;

        Slots = new ItemSlot[SlotPanel.childCount];

        for (int i = 0; i < Slots.Length; i++) 
        {
            Slots[i] = SlotPanel.GetChild(i).GetComponent<ItemSlot>();
            
        }

    }

    public void WheelEquip(InputAction.CallbackContext context) //휠업시 UI가 빗나는거
    {
        if(context.phase == InputActionPhase.Started) 
        {
            Vector2 vector = context.ReadValue<Vector2>();
            if (vector.y > 0) 
            {
                WheelUpEquip(context);
            } else if(vector.y < 0)
            {
                WheelDownEquip(context);
            }
        
            
            //## UpdateUI
        }
    }

    public void WheelUpEquip(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            ItemData _data = GameManager.Instance.Player.HandItemData;

            ItemData _newData = null;
            for (int i = 0; i < Slots.Length; i++)
            {
                if (i != Slots.Length)
                {
                    if (_data == Slots[i].Data && Slots[i + 1].Data != null)
                    {
                        _newData = Slots[i + 1].Data;
                        break;
                    }
                    else 
                    {
                        _newData = Slots[0].Data;
                    }
                }
                else
                {
                    _newData = Slots[0].Data;
                }
            }
            GameManager.Instance.Player.Equipment.EquipNew(_newData);

        }
    }

    public void WheelDownEquip(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            ItemData _data = GameManager.Instance.Player.HandItemData;

            ItemData _newData = null;
            for (int i = Slots.Length-1; i >= 0; i--)
            {
                if (i != 0)
                {
                    if (_data == Slots[i].Data)
                    {
                        _newData = Slots[i - 1].Data;
                        break;
                    }
                    else
                    {
                        _newData = Slots[0].Data;
                    }
                }
                else
                {
                    for (int j = Slots.Length - 1; j >= 0; j--) 
                    {
                        if (Slots[j].Data != null) 
                        {
                            _newData = Slots[j].Data;
                            break;
                        }
                    }
                    
                }
            }
            GameManager.Instance.Player.Equipment.EquipNew(_newData);
        }
    }

    public void ChangeEquip(InputAction.CallbackContext context) 
    {
        if (int.TryParse(context.control.name, out int _new) && context.phase == InputActionPhase.Started) 
        {
            GameManager.Instance.Player.Equipment.EquipNew(Slots[_new-1].Data);
        }
        //## UpdateUI
    }

    void AddItem() 
    {
        ItemData _data = GameManager.Instance.Player.ItemData;
        
        if (_data.CanStack) 
        {
            ItemSlot _slot = GetItemStack(_data);
            if (_slot != null) 
            {
                _slot.Quantity++;
                UpdateUI(_slot);
                GameManager.Instance.Player.ItemData = null;
                return;
            }
        }
        ItemSlot _emptySlot = GetEmptySlot();
        if (_emptySlot != null) 
        {
            _emptySlot.Data = _data;
            _emptySlot.Quantity = 1;
            UpdateUI(_emptySlot);
            GameManager.Instance.Player.ItemData = null;
            return;
        }
    }

    public void UpdateUI(ItemSlot slot)
    {
       
        for (int i = 0; i < Slots.Length; i++) 
        {
            if (Slots[i].Data != null)
            {
                Slots[i].Set();
            }
            else 
            {
                Slots[i].Clear();
            }
        }
    }

    private ItemSlot GetItemStack(ItemData data)
    {
        for (int i = 0; i < Slots.Length; i++) 
        {
            if (Slots[i].Data == data) 
            {
                return Slots[i];
            }
        }
        return null;
    }

    private ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            if (Slots[i].Data == null)
            {
                return Slots[i];
            }
        }
        return null;
    }


    public void UseItemInSlot(int slotIndex)
    {
        while (slotIndex + 1 < _curEmptySlot)
        {
            Slots[slotIndex].Icon.sprite = Slots[slotIndex + 1].Icon.sprite;
            Slots[slotIndex].Data = Slots[slotIndex + 1].Data;
            if (Slots[slotIndex + 1].Icon.sprite == null) break;
            slotIndex++;
        }
        _curEmptySlot--;
    }

    // 아이템 먹기를 여기서 구현해야 하나 ?
}
