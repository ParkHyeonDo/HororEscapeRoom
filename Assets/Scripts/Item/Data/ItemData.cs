using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
{
    Equipable,
    Consumable,
    Key
}

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

[CreateAssetMenu(fileName = "Item", menuName = "New Item", order = 0)]
public class ItemData : ScriptableObject
{
    public ItemType ItemType;
    [SerializeField] private int _maxStack;
    public int CurStack;

    [Header("Comsume")]
    public ItemEffect[] Effect;
}


