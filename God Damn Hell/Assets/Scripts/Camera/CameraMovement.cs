using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Quaternion cameraRotation;
    public GameObject playerObject;
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
        transform.position = new Vector3(playerObject.transform.position.x, Height, playerObject.transform.position.z - Distance);

        //Once the settings have been figured out this should be moved to Start()
        cameraRotation.eulerAngles = new Vector3(Angle, 0, 0);
        transform.localRotation = cameraRotation;
    }
}