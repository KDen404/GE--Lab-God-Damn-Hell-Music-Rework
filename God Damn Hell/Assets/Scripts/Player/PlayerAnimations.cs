using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playermovement;
    private PlayerStats playerstats;
    private float angle;
    private Vector2 movementAxis;
    private float timeSinceAttack;
    public bool stopRotation = false;

    public GameObject sword;
    private Collider swordCollider;

    public GameObject shield;
    private Collider shieldCollider;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerstats = GetComponent<PlayerStats>();
        playermovement = GetComponent<PlayerMovement>();
        swordCollider = sword.GetComponent<BoxCollider>();
        shieldCollider = shield.GetComponent<BoxCollider>();
    }

    private void Update()
    {
        Run();
        Attack();
        Die();
        Block();
    }

    // Angle calculations for rotations are being used to determine which animations play depending on the cursors position
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
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("AttackTrigger");
        }

        if (animator.GetCurrentAnimatorStateInfo(1).IsName("Attack"))
        {
            swordCollider.enabled = true;
        }
        else
        {
            swordCollider.enabled = false;
        }
    }

    private void Die()
    {
        if (playerstats.healthPoints <= 0)
        {
            if (!animator.GetCurrentAnimatorStateInfo(1).IsName("Die"))
            {
                animator.SetTrigger("IsDead");
            }

            stopRotation = true;
        }
        else
        {
            stopRotation = false;
        }
    }

    private void Block()
    {
        if (Input.GetAxis("Fire2") != 0)
        {
            animator.SetBool("isBlocking", true);
        }
        else
        {
            animator.SetBool("isBlocking", false);
        }

        if (animator.GetCurrentAnimatorStateInfo(1).IsName("Block"))
        {
            shieldCollider.enabled = true;
        }
        else
        {
            shieldCollider.enabled = false;
        }
    }
}




