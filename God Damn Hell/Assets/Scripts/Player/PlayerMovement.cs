using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    private Rigidbody player;
    public float angle;
    private bool stopRotation;
    private bool stopMovement;
    private PlayerAnimations playerAnimations;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
        playerAnimations = GetComponent<PlayerAnimations>();
    }

    private void Update()
    {
        stopRotation = playerAnimations.stopRotation;
        stopMovement = playerAnimations.stopMovement;
    }

    private void FixedUpdate()
    {
        PlayerMove();
        PlayerRotate();
    }

    private void PlayerMove()
    {
        // Moves the player object with WADS
        if (stopMovement == false)
        {
            player.MovePosition(new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")) * movementSpeed * Time.deltaTime + transform.position);
        }
    }

    private void PlayerRotate()
    {
        // Calculates the rotation using cursor position and player position
        if (stopRotation == false)
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 objectPosition = Camera.main.WorldToScreenPoint(transform.position);
            mousePosition.x = mousePosition.x - objectPosition.x;
            mousePosition.y = mousePosition.y - objectPosition.y;
            angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
            player.MoveRotation(Quaternion.Euler(new Vector3(0, -angle + 90, 0)));
        }
    }
}
