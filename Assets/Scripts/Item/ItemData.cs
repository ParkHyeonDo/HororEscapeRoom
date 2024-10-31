using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType 
{
    Key,
    Consumable,
    Note
}


[CreateAssetMenu(fileName ="Item", menuName ="New Item")]
public class ItemData : ScriptableObject
{
    [Header("Info")]
    public string DisplayName;
    public string Description;
    public ItemType Type;
    public Sprite Icon;
    public bool CanStack;
    public float FillValue;
}
