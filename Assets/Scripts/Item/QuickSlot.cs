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
    //private PlayerCondition condition;

    // Start is called before the first frame update
    void Start()
    {
        // controller = �ν��Ͻ�.controller
        // condition = �ν��Ͻ�.condition
        // controller.�پ����� += WheelUpEquip;
        // controller.�ٴٿ� ���� += WheelDownEquip;

        Slots = new ItemSlot[SlotPanel.childCount];

        for (int i = 0; i < Slots.Length; i++) 
        {
            Slots[i] = SlotPanel.GetChild(i).GetComponent<ItemSlot>();
        }

    }

    public void WheelUpEquip(InputAction.CallbackContext context) 
    {
        // ĳ���� ���� ��� ����
    }

    public void WheelDownEquip(InputAction.CallbackContext context)
    {
        // ĳ���� ���� ��� ����
    }

    void AddItem() 
    {
        ItemData _data = null; //## �����ʿ�

        if (_data.CanStack) 
        {
            ItemSlot _slot = GetItemStack(_data);
            if (_slot != null) 
            {
                _slot.Quantity++;
                UpdateUI();
                // ## �ν��Ͻ��� ������ִ� �����۵����� �ʱ�ȭ
                return;
            }
        }
        ItemSlot _emptySlot = GetEmptySlot();
        if (_emptySlot != null) 
        {
            _emptySlot.Data = _data;
            _emptySlot.Quantity = 1;
            UpdateUI();
            // ## �ν��Ͻ��� ������ִ� �����۵����� �ʱ�ȭ
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

}
