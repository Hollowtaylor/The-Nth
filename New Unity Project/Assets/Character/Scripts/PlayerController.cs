using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    private InputControls _controls;
    
    [SerializeField]protected float speed;
    
    private bool _moving;
    private float _movDir;
    private bool _jump;

    private void Awake()
    {
        _controls = new InputControls();
        _controls.Enable();

        _controls.Player.Move.started += OnMoveOnStarted;
        _controls.Player.Move.canceled += ctx => _moving = false;
        _controls.Player.Jump.performed += _ => _jump = true;
    }
    

    private void OnMoveOnStarted(InputAction.CallbackContext ctx)
    {
        _movDir = ctx.ReadValue<float>();
        _moving = true;
    }
    
    private void FixedUpdate()
    {
        if (_moving)
        {
            Move();
        }

        if (_jump)
        {
            Jump();
        }

    }

    private void Move()
    {
        var direction = new Vector3(_movDir * speed * Time.deltaTime, 0);
        transform.position += direction;
    }

    public void Jump()
    {
        var direction = _moving
            ? new Vector3(_movDir * speed * Time.deltaTime, 1 * speed * Time.deltaTime)
            : new Vector3(0, 1 * speed * Time.deltaTime);
        transform.position += direction;
        _jump = false;
    }
}
