using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(PlayerController))]
public class CharacterBase : MonoBehaviour
{
    private PlayerController _controller;
    
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
        _controller = GetComponent<PlayerController>();
    }

}
