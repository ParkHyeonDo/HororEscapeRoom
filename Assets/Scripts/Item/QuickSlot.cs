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

    private PlayerController _controller;
    private int _curEmptySlot;
    //private PlayerCondition condition;  ##


    void Start()
    {
        // controller = 인스턴스.controller
        // condition = 인스턴스.condition
        // controller.휠업연결 += WheelUpEquip;
        // controller.휠다운 연결 += WheelDownEquip;

        Slots = new ItemSlot[SlotPanel.childCount];

        for (int i = 0; i < Slots.Length; i++) 
        {
            Slots[i] = SlotPanel.GetChild(i).GetComponent<ItemSlot>();
        }

    }

    public void WheelUpEquip(InputAction.CallbackContext context) 
    {
        //## 캐릭터 장착 장비 변경
    }

    public void WheelDownEquip(InputAction.CallbackContext context)
    {
        //## 캐릭터 장착 장비 변경
    }

    void AddItem() 
    {
        ItemData _data = null; //## 수정필요

        if (_data.CanStack) 
        {
            ItemSlot _slot = GetItemStack(_data);
            if (_slot != null) 
            {
                _slot.Quantity++;
                UpdateUI();
                // ## 인스턴스에 저장되있는 아이템데이터 초기화
                return;
            }
        }
        ItemSlot _emptySlot = GetEmptySlot();
        if (_emptySlot != null) 
        {
            _emptySlot.Data = _data;
            _emptySlot.Quantity = 1;
            UpdateUI();
            // ## 인스턴스에 저장되있는 아이템데이터 초기화
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
            /*Slots[slotIndex].Item = Slots[slotIndex + 1].Item;*/
            if (Slots[slotIndex + 1].Icon.sprite == null) break;
            slotIndex++;
        }
        _curEmptySlot--;
    }

    // 아이템 먹기를 여기서 구현해야 하나 ?
}
