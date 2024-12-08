using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

// Camera Follow: keep the camera's position updated with the player's movement
public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private float cameraOnX = 0;
    private float cameraOnY = 0;
    private float cameraOnZ = -20;

    // Update is called once per framedw
    void Update()
    {
        Vector3 cameraPosition = player.transform.position;
        cameraPosition.x += cameraOnX;
        cameraPosition.y += cameraOnY;
        cameraPosition.z = cameraOnZ;
        transform.position = cameraPosition;

    }
}
