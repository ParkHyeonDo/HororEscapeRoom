using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    private GameObject _interactGameObject;
    private Camera _camera;
    [SerializeField] private float _maxCheckDistance;
    public TextMeshProUGUI Text;
    IInteractable _interactable;
    [SerializeField]private LayerMask _layerMask;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = _camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _maxCheckDistance, _layerMask))
        {
            if (hit.collider.gameObject != _interactGameObject)
            {

                _interactGameObject = hit.collider.gameObject;
                _interactable = hit.collider.GetComponent<ItemObject>();
                SetPromptText();
            }
        }
        else
        {
            _interactGameObject = null;
            _interactable = null;
            Text.gameObject.SetActive(false);
        }
    }

    private void SetPromptText()
    {
        Text.gameObject.SetActive(true);
        Text.text = _interactable.InteractPrompt();
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && _interactGameObject != null && _interactGameObject.CompareTag("Item"))
        {
            _interactable.OnInteracrt();
            _interactGameObject = null;
            _interactable = null;
            Text.gameObject.SetActive(false);

        }
        else if (context.phase == InputActionPhase.Started && _interactGameObject != null && _interactGameObject.CompareTag("Note"))
        {
            //노트에 추가
            //노트 오브젝트 삭제
        }
        else if (context.phase == InputActionPhase.Started && _interactGameObject != null && _interactGameObject.CompareTag("Things")) 
        {
            //상호작용
        }
    }
}
