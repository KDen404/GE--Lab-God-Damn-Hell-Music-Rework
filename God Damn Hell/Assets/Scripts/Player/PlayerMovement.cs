using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Rigidbody player;

    private Vector3 movement;

    private void Start()
    {
        player = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical")) * movementSpeed * Time.deltaTime;
        player.MovePosition(transform.position + movement);
    }
}
