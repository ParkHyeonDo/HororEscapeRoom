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

    public void WheelEquip(InputAction.CallbackContext context) //ÈÙ¾÷½Ã UI°¡ ºø³ª´Â°Å
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
            if (_data == null) return;
            ItemData _newData = null;
            for (int i = 0; i < Slots.Length; i++)
            {
                if (i != Slots.Length)
                {
                    if (_data == Slots[i].Data && Slots[i + 1].Data != null)
                    {
                        _newData = Slots[i + 1].Data;
                        _equipNum = i + 1;
                        break;
                    }
                    else 
                    {
                        _newData = Slots[0].Data;
                        _equipNum = 0;
                    }
                }
                else
                {
                    _newData = Slots[0].Data;
                    _equipNum = 0;
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
            if (_data == null) return;
            ItemData _newData = null;
            for (int i = Slots.Length-1; i >= 0; i--)
            {
                if (i != 0)
                {
                    if (_data == Slots[i].Data)
                    {
                        _newData = Slots[i - 1].Data;
                        _equipNum = i - 1;
                        break;
                    }
                    else
                    {
                        _newData = Slots[0].Data;
                        _equipNum = 0;
                    }
                }
                else
                {
                    for (int j = Slots.Length - 1; j >= 0; j--) 
                    {
                        if (Slots[j].Data != null) 
                        {
                            _newData = Slots[j].Data;
                            _equipNum = j;
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
            _equipNum = _new - 1;
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
                UpdateUI();
                GameManager.Instance.Player.ItemData = null;
                return;
            }
        }
        ItemSlot _emptySlot = GetEmptySlot();
        if (_emptySlot != null) 
        {
            _emptySlot.Data = _data;
            _emptySlot.Quantity = 1;
            UpdateUI();
            GameManager.Instance.Player.ItemData = null;
            return;
        }
    }

    public void UpdateUI()
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
        _curEmptySlot = Slots.Length - slotIndex;
        while (slotIndex + 1 < _curEmptySlot)
        {
            if (Slots[slotIndex + 1].Data == null || slotIndex == Slots.Length) 
            {
                Slots[slotIndex].Icon.sprite = null;
            }
            Slots[slotIndex].Data = Slots[slotIndex + 1].Data;
            UpdateUI();
            slotIndex++;
        }
        
    }

    public void RemoveItem() 
    {
        Slots[_equipNum].Quantity--;
        UpdateUI();
        if (Slots[_equipNum].Quantity <= 0) 
        {
            Slots[_equipNum].Data = null;
            UseItemInSlot(_equipNum);
            GameManager.Instance.Player.Equipment.EquipNew(Slots[0].Data);
                
                

        }
    }
}
