using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController Controller;
    public GameObject InteractTargetObject;
    public PlayerCondition Condition;
    public ItemData ItemData;
    public Action AddItem;

    private void Awake()
    {
        Controller = GetComponent<PlayerController>();
        GameManager.Instance.Player = this;
    }
}
