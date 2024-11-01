using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ConsumeType
{
    Temporaly,
    Durably,
}
public enum TargetStat
{
    Battery,
    Stamina
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item/Default", order = 0)]
public class ItemData : ScriptableObject
{
    public Image ItemIcon;
    public string DisplayName;
    public string Description;
    public Sprite Icon;
    [Header("Stack")]
    public bool CanStack;
    [SerializeField] private int _maxStack;
    public int CurStack;

    public virtual void Interact()
    {
        //아이템 슬롯에 추가
    }
}
