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

    // Takes the players position and recalculates it with given numbers for its own position
    // This is necessary as the constraints Unity provides cause massive issues in the compiled version of the game
    void LateUpdate()
    {
        transform.position = new Vector3(playerObject.transform.position.x, Height, playerObject.transform.position.z - Distance);

        cameraRotation.eulerAngles = new Vector3(Angle, 0, 0);
        transform.localRotation = cameraRotation;
    }
}