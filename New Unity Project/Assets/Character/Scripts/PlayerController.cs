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
    
    private void Awake()
    {
        _controls = new InputControls();
        _controls.Enable();

        _controls.Player.Move.started += OnMoveOnStarted;
        _controls.Player.Move.canceled += ctx => _moving = false;
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

    }

    private void Move()
    {
        var direction = new Vector3(_movDir * speed * Time.deltaTime, 0);
        transform.position += direction;
    }



}
