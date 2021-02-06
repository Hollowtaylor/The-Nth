using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class CharacterBase : MonoBehaviour
{
    private PlayerController _controller;
    
    [Header("Stats")]
    [SerializeField]protected float health;
    [SerializeField]protected float xp;
    [SerializeField]protected float damage;
    [SerializeField]protected float armour;

    public enum States  { Idle, Moving, Jump, Attacking }

    [SerializeField] private States state = States.Idle;
    


    public States State {
        get => state;
        set => state = value;
    }


    private void Awake()
    {
        _controller = GetComponent<PlayerController>();
    }

    protected void FixedUpdate()
    {
        switch (state)
        {
            case States.Idle:
                break;
            case States.Moving:
                _controller.Move();
                break;
            case States.Jump:
                _controller.Jump();
                break;
            case States.Attacking:
                break;
        }
    }
}
