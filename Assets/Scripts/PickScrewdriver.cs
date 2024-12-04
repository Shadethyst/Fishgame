using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;

public class PickScrewdriver : MonoBehaviour
{
    [SerializeField] GameObject player;

    public bool isPickedUp;
    public int sdCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void Update()
    {
    }

    public void screwdriverAdded(){
        sdCount++;
        isPickedUp = true;
    }


    private void OnTriggerEnter2D(Collider2D Screwdriver)
    {
        if (Screwdriver.gameObject.tag.Equals("Player") && !isPickedUp)
        {
            Debug.Log("Player picked Screwdriver!");
        }
        

    }

}