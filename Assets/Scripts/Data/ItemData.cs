using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum ItemType
{
    Equipable,
    Consumable,
    Key,
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
    public bool CanStack;
    public int CurStack;
    public Image ItemIcon;
    public string DisplayName;
    public string Description;
    public Sprite Icon;

    [Header("Comsume")]
    public ItemEffect[] Effect;
}


