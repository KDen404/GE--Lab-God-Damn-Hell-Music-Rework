using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Quaternion cameraRotation;
    public PlayerMovement playerMovement;
    private Vector3 cameraPosition;

    // Temporary variables to figure out perfect settings
    public int Angle = 60;
    public int Height = 13;
    public int Distance = 8;

    void Start()
    {
        
    }
    void LateUpdate()
    {
        cameraPosition = new Vector3(playerMovement.transform.position.x, Height, playerMovement.transform.position.z - Distance);
        transform.position = cameraPosition;

        // Once the settings have been figured out this should be moved to Start()
        cameraRotation.eulerAngles = new Vector3(Angle, 0, 0);
        transform.localRotation = cameraRotation;
    }
}