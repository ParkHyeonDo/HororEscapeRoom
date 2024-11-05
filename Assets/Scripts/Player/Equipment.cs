using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;


public class Equipment : MonoBehaviour
{
    public Item CurEquip;
    public Transform EquipParent;

    private PlayerController _controller;
    private PlayerCondition _condition;

    private void Start()
    {
        _controller = GetComponent<PlayerController>();
        _condition = GetComponent<PlayerCondition>();
    }

    public void EquipNew(ItemData data)
    {
        UnEquip();
        CurEquip = Instantiate(data.EquipPrefab, EquipParent).GetComponent<Item>();
        GameManager.Instance.Player.HandItemData = data;
    }


    public void UnEquip()
    {
        if (CurEquip != null)
        {
            Destroy(CurEquip.gameObject);
            CurEquip = null;
        }
    }

    public void MouseClick(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && CurEquip != null)
        {
            if (CurEquip.ItemData.GetType() == typeof(Consumable))
            {
                Consumable data = (Consumable)CurEquip.ItemData;
                for (int i = 0; data.Effect.Length > i; i++)
                {
                    if (data.Effect[i].TargetStat == TargetStat.Battery && 
                        data.Effect[i].ConsumeType == ConsumeType.Temporaly)
                    {
                        _condition.ChargeBattery(data.Effect[i].Value);
                    }
                }
            }
            else if(CurEquip.ItemData.GetType() == typeof(Key))
            {
                //키 사용
            }
            else return;
        }
    }
}

