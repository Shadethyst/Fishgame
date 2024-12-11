using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] public PickScrewdriver screwdriver;
    public UnityEvent doorOpening;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && screwdriver.isPickedUp)
        {
            gameObject.SetActive(false);
            doorOpening.Invoke();
        }
    }
}
