using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private BoxCollider2D chestCollider;
    
    
    
    private void Awake()
    {
        chestCollider = this.GetComponent<BoxCollider2D>();
       
    }

    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Im a mothafucking chest boi");
        }
        
}
}
