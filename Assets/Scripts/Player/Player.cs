using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController Controller;
    public GameObject InteractTarget;
    public PlayerCondition Condition;
    public Equipment Equipment;
    public ItemData ItemData;
    public ItemData HandItemData;
    public Action AddItem;
    public QuickSlot QuickSlot;
    

    private void Awake()
    {
        Controller = GetComponent<PlayerController>();
        Condition = GetComponent<PlayerCondition>();
        Equipment = GetComponent<Equipment>();
        GameManager.Instance.Player = this;
    }
}
