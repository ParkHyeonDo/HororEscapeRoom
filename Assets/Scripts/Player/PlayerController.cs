using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    IEnumerator UseStamina()
    {
        while (_hasStamina)
        {
            yield return new WaitForSecondsRealtime(0.1f);
            _condition.UseStamina(2);
            if (_condition.Stamina.CurValue < 2) 
            {
                _hasStamina = false;
            }
        }
        Speed = 2.0f;
        StopCoroutine(_coroutine);
    }

    private IEnumerator _coroutine;
    public event Action Interaction;
    public event Action OnNote;
    public event Action OnPause;

    [Header("Move")]
    public float Speed = 2f;
    private Vector2 _moveInput;
    [SerializeField] private LayerMask _stair;
    public float MaxSlopeAngle;

    [Header("Look")]
    [SerializeField] private Transform CameraContainer;
    private readonly float _minXLook = -85f;
    private readonly float _maxXLook = 85f;
    private float _camXRot;
    private Vector2 _mouseDelta;
    private bool _isNoteON;
    private bool _hasStamina;
    public float MouseSensitive;
    private float _mouseScrollDelta;

    private bool _isPause;

    public Rigidbody RigidBody;
    private PlayerCondition _condition;

    public Action WheelChangeEquip;
    public Action NumChangeEquip;

    public EscUI EscUI;

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody>();
        _condition = GetComponent<PlayerCondition>();
    }

    private void Start()
    {
        EscUI = FindObjectOfType<EscUI>();
        OnPause += Pause;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    { 
        if (_isPause == false)
        Move();
    }

    private void LateUpdate()
    {
        if(_isPause == false)
        Look();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            _moveInput = context.ReadValue<Vector2>();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            _moveInput = Vector2.zero;
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        _mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            Interaction?.Invoke();
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed && _condition.Stamina.CurValue > 0 )
        {
            _hasStamina = true;
            Speed = 3.3f;
            _coroutine = UseStamina();
            StartCoroutine(_coroutine);
        }
        else if(context.phase == InputActionPhase.Canceled || _condition.Stamina.CurValue < 2)
        {
            _hasStamina = false;
            Speed = 2.0f;
            StopCoroutine(_coroutine);
        }
    }


    public void OnNoteUI(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            OnNote?.Invoke();
        }
    }

    public void OnTempPause(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {

            OnPause?.Invoke();
            if (EscUI != null)
            {
                if (EscUI.ESCUI.activeSelf)
                {
                    EscUI.ESCUI.SetActive(false);
                    Cursor.lockState = CursorLockMode.Locked;
                    _isPause = false;
                }
                else
                {
                    EscUI.ESCUI.SetActive(true);
                    Cursor.lockState = CursorLockMode.None;
                    _isPause = true;
                }
            }
        }
    }

    private void Look()
    {
        _camXRot += _mouseDelta.y * MouseSensitive;
        _camXRot = Mathf.Clamp(_camXRot, _minXLook, _maxXLook);
        CameraContainer.localEulerAngles = new Vector3(-_camXRot, 0, 0);
        transform.eulerAngles += new Vector3(0, _mouseDelta.x * MouseSensitive);
    }

    private void Move()
    {
        Vector3 dir = transform.forward * _moveInput.y + transform.right * _moveInput.x;
        dir *= Speed;
        Ray frontRay = new Ray(transform.position + Vector3.up * 0.1f, dir);
        Debug.DrawRay(transform.position + Vector3.up * 0.1f, dir);

        RaycastHit hit; 
        if (Physics.Raycast(frontRay, out hit, 1f, _stair))
        {
            dir.y = 1.5f;
        }
        else dir.y = RigidBody.velocity.y;

        RigidBody.velocity = dir;
    }

    private void Pause()
    {
        if (_isPause == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            _isPause = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            _isPause = true;
        }
    }

    public void UpdatePauseState(bool isPaused)
    {
        _isPause = isPaused;
        if (isPaused)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
