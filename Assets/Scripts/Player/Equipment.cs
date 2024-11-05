using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;


public class Equipment : MonoBehaviour
{
    public Equip CurEquip;
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
        CurEquip = Instantiate(data.EquipPrefab, EquipParent).GetComponent<Equip>();
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
            if (CurEquip.CompareTag("ConsumableEquip")) 
            {
                Consumable data = CurEquip.GetComponent<Consumable>();
                for (int i = 0; i < data.Effect.Length; i++) 
                {
                    switch (data.Effect[i].TargetStat) 
                    {
                        case TargetStat.Stamina:
                            
                            break;
                        case TargetStat.Battery:
                            GameManager.Instance.Player.Condition.ChargeBattery(data.Effect[i].Value);
                            Debug.Log("들어옴?");
                            break;
                    }

                }
            } else if (CurEquip.CompareTag("Equip")) 
            {
                Debug.Log(CurEquip);
                CurEquip.MouseClick();
            }
            
        }
    }
}

