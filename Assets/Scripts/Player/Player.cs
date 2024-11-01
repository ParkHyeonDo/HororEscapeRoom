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
    public Action AddItem;

    private void Awake()
    {
        Controller = GetComponent<PlayerController>();
        GameManager.Instance.Player = this;
    }
}
