using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    private float cameraOnX = 0;
    private float cameraOnY = 0;
    private float cameraOnZ = -10;

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = player.transform.position;
        cameraPosition.x += cameraOnX;
        cameraPosition.y += cameraOnY;
        cameraPosition.z = cameraOnZ;
        transform.position = cameraPosition;

    }
}
