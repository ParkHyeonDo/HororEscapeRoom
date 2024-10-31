using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class QuickSlotUI : MonoBehaviour
{
    public QuickSlot[] Slots=new QuickSlot[5];
    private int _curEmptySlot;

    private void Start()
    {
        _curEmptySlot = 0;
    }
    public void GetItem(/*itemData item*/)
    {
        if(_curEmptySlot < Slots.Length)
        {
            /*slots[_curEmptySlot].itemData = item*/
            Slots[_curEmptySlot].Icon = /*itemData.Icon*/null;
            _curEmptySlot++;
        }
        else
        {
            Debug.Log("공간이 부족합니다");
        }
    }

    public void UseItemInSlot(int slotIndex)
    {
        while (slotIndex+1 < _curEmptySlot) 
        {
            Slots[slotIndex].Icon.sprite = Slots[slotIndex + 1].Icon.sprite;
            /*Slots[slotIndex].Item = Slots[slotIndex + 1].Item;*/
            if (Slots[slotIndex + 1].Icon.sprite == null) break;
            slotIndex++;
        }
        _curEmptySlot--;
    }
}
