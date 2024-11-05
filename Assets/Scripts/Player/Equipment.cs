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
        Debug.Log(CurEquip);
        UnEquip();
        CurEquip = Instantiate(data.EquipPrefab, EquipParent).GetComponent<Equip>();
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
        if (context.phase == InputActionPhase.Performed && CurEquip != null) 
        {
            CurEquip.MouseClick();
        }
    }
}

