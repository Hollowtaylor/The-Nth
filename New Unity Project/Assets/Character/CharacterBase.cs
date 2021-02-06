using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

public class CharacterBase : MonoBehaviour
{
    private InputControls _controls;
    
    [Header("Stats")]
    [SerializeField]protected float health;
    [SerializeField]protected float xp;
    [SerializeField]protected float damage;
    [SerializeField]protected float armour;
    
    public enum States  { Idle, Moving, Attacking }

    [SerializeField] private States state = States.Idle;

    public States State {
        get => state;
        protected set => state = value;
    }


    private void Awake()
    {
        _controls = new InputControls();
        _controls.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }

    // Start is called before the first frame update
    protected void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }

    protected void Move(Vector2 direction)
    {
        Debug.Log("Moving: " + direction);
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }
}
