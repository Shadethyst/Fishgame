using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeactivator : MonoBehaviour
{
    [SerializeField] PlayerController playerController;

    public void DeactivatePlayer()
    {
        playerController.SetInControl(false);
        playerController.SetVisibility(false);
    }
}
