using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Events;
using System;

public class DamageOnCollision : MonoBehaviour
{

    public UnityEvent OnDamageTaken;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /*
     When an object collides with the enemy with this script, it checks if the colliding object is the player,
    if it is it invokes the OnDamageTaken event, which calls a function,
    currently use case is to call takeDamage in the PlayerHealth script to deal damage to the player
    and also can be used to call PlayerController to add knockback for example
     
     
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            OnDamageTaken.Invoke();
            Debug.Log("Player collided!");
        }
        

    }
}
