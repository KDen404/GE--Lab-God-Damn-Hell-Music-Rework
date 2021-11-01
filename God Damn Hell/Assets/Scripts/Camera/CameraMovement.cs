using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Quaternion cameraRotation;
    private PlayerMovement playerMovement;
    private Vector3 cameraPosition;

    void Start()
    {
        cameraRotation.eulerAngles = new Vector3(60, 0, 0);
        transform.localRotation = cameraRotation;

        playerMovement = FindObjectOfType<PlayerMovement>();
    }
    void LateUpdate()
    {
        cameraPosition = new Vector3(playerMovement.transform.position.x, 13, playerMovement.transform.position.z - 8);
        transform.position = cameraPosition;
    }
}