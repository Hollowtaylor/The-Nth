using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private CharacterController _characterController;
    
    
    public PlayerController(CharacterController characterController)
    {
        _characterController = characterController;
    }


    public void MoveCharacter(InputValue value)
    {
        _characterController.Move(value.Get<Vector2>());
    }

    public void MoveRight()
    {
        
    }



}
