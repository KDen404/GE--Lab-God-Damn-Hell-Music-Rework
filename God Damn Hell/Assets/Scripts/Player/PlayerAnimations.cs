using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    public PlayerMovement playermovement;
    private float angle;
    private Vector2 movementAxis;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        Run();
        Attack();

        Debug.Log("MovementForward: " + animator.GetFloat("MovementForward") + " and MovementSides: " + animator.GetFloat("MovementSides"));
    }

    private void Run()
    {
        angle = playermovement.angle;

        movementAxis.x = Input.GetAxisRaw("Horizontal");
        movementAxis.y = Input.GetAxisRaw("Vertical");

        if (angle <= 180 && angle > 90)
        {
            if (angle <= 180 && angle > 150)
            {
                animator.SetFloat("MovementForward", -movementAxis.x);
                animator.SetFloat("MovementSides", movementAxis.y);
            }
            else if (angle < 150 && angle > 120)
            {
                animator.SetFloat("MovementForward", movementAxis.y);
                animator.SetFloat("MovementSides", movementAxis.x);
            }
            else if (angle < 120 && angle >= 90)
            {
                animator.SetFloat("MovementForward", movementAxis.y);
                animator.SetFloat("MovementSides", movementAxis.x);
            }
        }

        if (angle <= 90 && angle > 0)
        {
            if (angle <= 90 && angle > 60)
            {
                animator.SetFloat("MovementForward", movementAxis.y);
                animator.SetFloat("MovementSides", movementAxis.x);
            }
            else if (angle < 60 && angle > 30)
            {
                animator.SetFloat("MovementForward", movementAxis.y);
                animator.SetFloat("MovementSides", movementAxis.x);
            }
            else if (angle < 30 && angle >= 0)
            {
                animator.SetFloat("MovementForward", movementAxis.x);
                animator.SetFloat("MovementSides", movementAxis.y);
            }
        }

        if (angle >= -180 && angle < -90)
        {
            if (angle >= -180 && angle < -150)
            {
                animator.SetFloat("MovementForward", -movementAxis.x);
                animator.SetFloat("MovementSides", -movementAxis.y);
            }
            else if (angle > -150 && angle < -120)
            {
                animator.SetFloat("MovementForward", -movementAxis.y);
                animator.SetFloat("MovementSides", -movementAxis.x);
            }
            else if (angle > -120 && angle <= -90)
            {
                animator.SetFloat("MovementForward", -movementAxis.y);
                animator.SetFloat("MovementSides", -movementAxis.x);
            }
        }

        if (angle >= -90 && angle < 0)
        {
            if (angle >= -90 && angle < -60)
            {
                animator.SetFloat("MovementForward", -movementAxis.y);
                animator.SetFloat("MovementSides", -movementAxis.x);
            }
            else if (angle > -60 && angle < -30)
            {
                animator.SetFloat("MovementForward", -movementAxis.y);
                animator.SetFloat("MovementSides", -movementAxis.x);
            }
            else if (angle > -30 && angle <= 0)
            {
                animator.SetFloat("MovementForward", movementAxis.x);
                animator.SetFloat("MovementSides", -movementAxis.y);
            }
        }
    }

    private void Attack()
    {
        // Attacks if the player currently is in the idle state (else it queues and starts once arrived)
        if (Input.GetButtonDown("Fire1") && animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            animator.SetTrigger("AttackTrigger");
        }
    }
}




