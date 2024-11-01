using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.InputSystem;

public class QuickSlot : MonoBehaviour
{
    public GameObject QuickSlotView;
    public Transform SlotPanel;
    public ItemSlot[] Slots;

    //private PlayerController _controller;
    private int _curEmptySlot;
    private PlayerCondition _condition;


    void Start()
    {
        //_controller = GameManager.Instance.Player.Controller;
        _condition = GameManager.Instance.Player.Condition;

        Slots = new ItemSlot[SlotPanel.childCount];

        for (int i = 0; i < Slots.Length; i++) 
        {
            Slots[i] = SlotPanel.GetChild(i).GetComponent<ItemSlot>();
        }

    }

    public void WheelUpEquip(InputAction.CallbackContext context) //휠업시 UI가 빗나는거
    {
        //## 캐릭터 장착 장비 변경
    }

    public void WheelDownEquip(InputAction.CallbackContext context)
    {
        //## 캐릭터 장착 장비 변경
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

    private void UpdateUI()
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
