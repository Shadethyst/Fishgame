using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.Events;
using System;
using UnityEngine.UI;

public class Scorepoints : MonoBehaviour
{

    public int pearlCount;
    public Text pearlText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pearlText.text = pearlCount.ToString();
    }

    public void pearlAdded(){
        pearlCount++;
    }

    private void OnTriggerEnter2D(Collider2D Pearl)
    {
        if (Pearl.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Player picked pearl!");
        }
        

    }

}

