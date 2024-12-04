using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public bool locked;
   
    void Start()
    {
        locked = true;
    }
    
    void Update()
    {
    }

    public void Open() {
        locked = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Screwdriver"))
        {
            Debug.Log("sd open the door!");
        }
        

    }

}
