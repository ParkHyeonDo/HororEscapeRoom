using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private float _range = 1;
    public LayerMask Interactable;
    private PlayerController _controller;

    private void Start()
    {
        _controller = GameManager.Instance.Player.Controller;
    }

    private void Update()
    {
        Ray ray = new Ray(new Vector3(Screen.width/2, Screen.height/2), Vector3.forward * _range);

        if(Physics.Raycast(ray, out RaycastHit hit, 1f, Interactable))
        {
            if (hit.collider.gameObject.TryGetComponent<Item>(out Item item))
            {
                _target = hit.collider.gameObject;
                GameManager.Instance.Player.InteractTargetObject = _target;
                ItemData data = item.ItemData;
            }
            if(hit.collider.gameObject.TryGetComponent<InteractableObject>(out InteractableObject obj))
            {
                _target = hit.collider.gameObject;
                GameManager.Instance.Player.InteractTargetObject = _target;
                InteractableData data = obj.Data;
            }
        }
    }
}
