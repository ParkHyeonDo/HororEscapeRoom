using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Progress;

public class Interact : MonoBehaviour
{
    private PlayerController _controller;
    public TextMeshProUGUI Text;
    public ConversationScreen ConversationScreen;

    [SerializeField] private GameObject _target;

    private float _range = 1f;
    public LayerMask TargetLayer;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        _controller = GameManager.Instance.Player.Controller;
        _controller.Interaction += Interactaction; //상호작용 이벤트 구독
    }
    private void Update()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        Debug.DrawRay(transform.position, transform.forward, Color.red, _range);
        if (Physics.Raycast(ray, out RaycastHit hit, _range, TargetLayer))
        {
            
            if (hit.collider.gameObject.TryGetComponent<Item>(out Item item))
            {
                _target = hit.collider.gameObject;
                GameManager.Instance.Player.InteractTarget = _target;
               
                ConversationScreen.SetText(item.GetPrompt()).SetActive(true);
            }
            else if (hit.collider.gameObject.TryGetComponent<InteractableObject>(out InteractableObject obj))
            {
                _target = hit.collider.gameObject;
                GameManager.Instance.Player.InteractTarget = _target;
                ConversationScreen.SetText(obj.GetPrompt()).SetActive(true);

            }
        }
        else
        {
            ConversationScreen.SetText(null).SetActive(false);
            _target = null;
            GameManager.Instance.Player.InteractTarget = null;
        }
    }

    private void Interactaction()
    {
        if (_target != null)
        {
            if(_target.TryGetComponent<Item>(out Item item))
            {
                item.Interact();
            }
            if (_target.TryGetComponent<InteractableObject>(out InteractableObject obj))
            {
                obj.Interact();
            }
        }
    }

}
