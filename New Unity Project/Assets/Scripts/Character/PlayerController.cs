using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    
    private InputControls _controls;
    private CharacterBase _character;
    private Rigidbody2D _rb;

    
    [SerializeField]protected float movDir;
    [SerializeField]protected float speed;
    [SerializeField]protected float jumpForce;
    
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isMoving;
    [SerializeField] private Vector2 _direction;

    private void Awake()
    {
        
        _rb = GetComponent<Rigidbody2D>();
        _character = GetComponent<CharacterBase>();
        _controls = new InputControls();
        _controls.Enable();  // activate the input system

        /*
         * Started - Key Held
         * Cancelled - Key Released
         * Performed - Key Pressed
         */
        _controls.Player.Move.started += OnMoveOnStarted;
        _controls.Player.Move.canceled += OnMoveOnCanceled;
        _controls.Player.Jump.performed += _ => _character.State = CharacterBase.States.Jump;
    }

    private void FixedUpdate()
    {
        if (_character.State == CharacterBase.States.Idle && isGrounded)
        {
            _rb.velocity = Vector2.zero;
            _direction = Vector2.zero;
        }
    }

    private void OnMoveOnCanceled(InputAction.CallbackContext ctx)
    {
        _character.State = CharacterBase.States.Idle;
        movDir = 0;
        isMoving = false;
    }


    private void OnMoveOnStarted(InputAction.CallbackContext ctx)
    {
        movDir = ctx.ReadValue<float>();
        isMoving = true;
        _character.State = CharacterBase.States.Moving;
    }


    public void Move()
    {
        // break if in air
        if(!isGrounded) return;
        _direction = Vector2.right * (movDir * speed);
        _rb.velocity = _direction;
    }

    public void Jump()
    {
        // break if in air
        if (!isGrounded) return;
        _direction += Vector2.up * jumpForce;
        _rb.velocity = _direction;
        isGrounded = false;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        
        isGrounded = true;
        _direction = new Vector2(_direction.x, 0);
        // ternary operator, true(left) / false(right) check
        _character.State = movDir == 0 ? CharacterBase.States.Idle : CharacterBase.States.Moving;
    }
    
}
