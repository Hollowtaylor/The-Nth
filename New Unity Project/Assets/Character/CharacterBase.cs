using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterBase : MonoBehaviour
{

    protected float Health;
    protected float Xp;
    protected float Damage;
    protected float Armour;

    public enum States  { Idle, Moving, Attacking }

    [SerializeField] private States state = States.Idle;
    
    public States State {
        get => state;
        protected set => state = value;
    }
    
    // Start is called before the first frame update
    protected void Start()
    {
        
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }
}
