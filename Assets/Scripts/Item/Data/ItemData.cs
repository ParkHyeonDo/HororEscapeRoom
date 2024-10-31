using System;
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

[Serializable]
public class ItemEffect
{
    public TargetStat TargetStat;
    public float Value;
}

[CreateAssetMenu(fileName = "Item", menuName = "New Item", order = 0)]
public class ItemData : ScriptableObject
{
    public ItemType ItemType;

    [Header("Comsume")]
    public ConsumeType ConsumeType;
    public ItemEffect[] Effect;
}


