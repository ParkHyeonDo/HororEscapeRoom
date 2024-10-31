using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public event Action Interaction;

    [Header("Move")]
    public float Speed = 2f;
    private Vector2 _moveInput;
    [SerializeField] private LayerMask _stair;

    [Header("Look")]
    [SerializeField] private Transform CameraContainer;
    private readonly float _minXLook = -85f;
    private readonly float _maxXLook = 85f;
    private float _camXRot;
    public float MouseSensitive;
    private Vector2 _mouseDelta;

    public Rigidbody RigidBody;

    private void Awake()
    {
        RigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
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
            Interaction.Invoke();
        }
    }

    public void OnSprint(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Performed/* && stamina > 0 */)
        {
            Speed = 3.3f;
        }
        else if(context.phase == InputActionPhase.Canceled )
        {
            Speed = 2.0f;
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
        //계단 각도 계산 후 rigidbody Y벡터값 추가예정
        //Ray[] rays = new Ray[2]
        //{
        //    new Ray(new Vector3(transform.position.x, transform.position.y - 1.5f), transform.forward),
        //    new Ray(new Vector3(transform.position.x, transform.position.y - 1.0f), transform.forward)
        //};


        Vector3 dir = transform.forward * _moveInput.y + transform.right * _moveInput.x;
        dir *= Speed;
        dir.y = RigidBody.velocity.y;

        RigidBody.velocity = dir;
    }
}
