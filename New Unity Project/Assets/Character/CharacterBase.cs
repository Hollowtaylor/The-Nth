using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class CharacterBase : MonoBehaviour
{
    private InputControls _controls;
    
    [Header("Stats")]
    [SerializeField]protected float health;
    [SerializeField]protected float xp;
    [SerializeField]protected float damage;
    [SerializeField]protected float armour;
    
    
    private bool _moving;
    private float _movDir;
    public enum States  { Idle, Moving, Attacking }

    [SerializeField] private States state = States.Idle;
    


    public States State {
        get => state;
        protected set => state = value;
    }


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

    // Start is called before the first frame update
    protected void Start()
    {
        
    }

    // Update is called once per frame
    protected void FixedUpdate()
    {
        if (_moving)
        {
            Move();
        }

    }

    protected void Move()
    {
        var direction = new Vector3(_movDir, 0);
        transform.position += direction;
    }

    // private void OnEnable()
    // {
    //     _controls.Enable();
    // }
    //
    // private void OnDisable()
    // {
    //     _controls.Disable();
    // }
}
