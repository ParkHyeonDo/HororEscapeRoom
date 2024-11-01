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
    public float UseStamina;

    private Animator _animator;
    private Camera _camera;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _camera = Camera.main;
    }

    public override void OnMouseClickInput()
    {
        if (!_clicking) 
        {
            _clicking = true;
            Invoke("OnCanClick", _clickRate);
        
        }
    }

    private void OnCanClick() 
    {
        _clicking = false;
    }

}

