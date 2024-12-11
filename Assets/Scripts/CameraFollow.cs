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
    [SerializeField] public float mapboundXUp;
    [SerializeField] public float mapboundYUp;
    [SerializeField] public float mapboundXDown;
    [SerializeField] public float mapboundYDown;
    Vector3 cameraPosition;

    private void Start()
    {
        cameraPosition = player.transform.position;
        cameraPosition.z = cameraOnZ;
    }
    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position.x < mapboundXUp) && (player.transform.position.x > mapboundXDown))
        {
            cameraPosition.x = player.transform.position.x;
        }
        if ((player.transform.position.y < mapboundYUp) && (player.transform.position.y > mapboundYDown)) {
            cameraPosition.y = player.transform.position.y;
        }
        cameraPosition.z = cameraOnZ;
        transform.position = cameraPosition;





    }
}
