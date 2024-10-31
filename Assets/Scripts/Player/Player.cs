using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController Controller;
    public GameObject InteractTargetObject;

    private void Awake()
    {
        Controller = GetComponent<PlayerController>();
        GameManager.Instance.Player = this;
    }
}
