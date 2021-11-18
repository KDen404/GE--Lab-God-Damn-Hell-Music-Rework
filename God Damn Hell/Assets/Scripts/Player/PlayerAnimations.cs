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

    }

    private void Run()
    {
        angle = playermovement.angle;
        Debug.Log(angle);

        movementAxis.x = Input.GetAxisRaw("Horizontal");
        movementAxis.y = Input.GetAxisRaw("Vertical");

        if (angle < 180 && angle > 90)
        {
            animator.SetFloat("MovementForward", movementAxis.y);
            animator.SetFloat("MovementSides", movementAxis.x);
        }

        if (angle < 90 && angle > 0)
        {
            animator.SetFloat("MovementForward", movementAxis.y);
            animator.SetFloat("MovementSides", movementAxis.x);
        }

        if (angle > -180 && angle < -90)
        {
            animator.SetFloat("MovementForward", -movementAxis.y);
            animator.SetFloat("MovementSides", -movementAxis.x);
        }

        if (angle > -90 && angle < 0)
        {
            animator.SetFloat("MovementForward", -movementAxis.y);
            animator.SetFloat("MovementSides", -movementAxis.x);
        }
    }

    private void Attack()
    {
        // Attacks if the player currently is in the idle state (else it queues and starts once arrived)
        if (Input.GetButtonDown("Fire1") && animator.GetCurrentAnimatorStateInfo(0).IsName("Armature_Idle_Sword_And_Shield"))
        {
            animator.SetTrigger("AttackTrigger");
        }
    }
}




