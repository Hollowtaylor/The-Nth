using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    
    private InputControls _controls;
    private CharacterBase _character;

    [SerializeField]protected float movDir;
    [SerializeField]protected float speed;
    [SerializeField]protected float jumpForce;
    
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isMoving;
    [SerializeField] private Vector3 _direction;

    private void Awake()
    {
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
        _direction = new Vector3(movDir * speed * Time.deltaTime, 0);
        transform.position += _direction;
    }

    public void Jump()
    {
        // break if in air
        if (!isGrounded) return;
        
        // ternary operator, true/false check
        _direction = !isMoving ? new Vector3(0, 10 * jumpForce * Time.deltaTime) : new Vector3(movDir * speed * Time.deltaTime, 10 * jumpForce * Time.deltaTime);
        transform.position += _direction;
        isGrounded = false;
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        // ternary operator, true/false check
        _character.State = movDir == 0 ? CharacterBase.States.Idle : CharacterBase.States.Moving;
    }

    public void OnCollisionStay2D(Collision2D other)
    {
        isGrounded = true;
    }
}
