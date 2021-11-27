using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Rigidbody player;
    public float angle;
    private bool stopRotation;
    public PlayerAnimations playerAnimations;

    private Vector3 movement;

    private void Update()
    {
        stopRotation = playerAnimations.stopRotation;
    }

    private void FixedUpdate()
    {
        playerMove();
        playerRotate();
    }

    private void playerMove()
    {
        // Moves the player object with WADS
        player.MovePosition(new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")) * movementSpeed * Time.deltaTime + transform.position);
    }

    private void playerRotate()
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
