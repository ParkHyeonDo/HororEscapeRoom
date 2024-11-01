using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController Controller;
    public GameObject InteractTarget;

    private void Awake()
    {
        Controller = GetComponent<PlayerController>();
        GameManager.Instance.Player = this;
    }
}
