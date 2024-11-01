using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interact : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private float _range = 1;
    public LayerMask Interactable;
    private PlayerController _controller;
    public TextMeshProUGUI Text;

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
    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && GameManager.Instance.Player.InteractTargetObject != null )
        {

        }
        else if (context.phase == InputActionPhase.Started && GameManager.Instance.Player.InteractTargetObject != null)
        {
            //노트에 추가
            //노트 오브젝트 삭제
        }
        else if (context.phase == InputActionPhase.Started && GameManager.Instance.Player.InteractTargetObject != null )
        {
            //상호작용
        }
    }

}
