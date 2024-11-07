using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class EquipTool : Equip
{
    [SerializeField]private float _clickRate;
    private bool _clicking;
    [HideInInspector]
    public float UseStamina;
    private Equip _curEquip;
    private GameObject _light;

    private Animator _animator;
    private Camera _camera;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _camera = Camera.main;
        _light = GameObject.Find("Flash");
    }

    public override void MouseClick()
    {
        //_curEquip = 
        if (!_clicking) 
        {
            _clicking = true;
            //animator.SetTrigger("Click");
            Invoke("OnCanClick", _clickRate);
        
        }
    }

    private void OnCanClick() 
    {
        _clicking = false;
    }

    public void OnCharge() 
    {
        ItemData _itemdata = GameManager.Instance.Player.ItemData;
        GameManager.Instance.Player.Condition.ChargeBattery(20); // ## 수정필요
    }

    public void OnFlash() 
    {
        if (!_light)
        {
            _light.SetActive(true);
        }
        else 
        {
            _light.SetActive(false);
        }
        
    }
}

