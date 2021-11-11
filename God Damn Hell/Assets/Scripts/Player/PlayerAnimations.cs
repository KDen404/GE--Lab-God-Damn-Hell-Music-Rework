using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        // Attacks if the player currently is in the idle state (else it queues and starts once arrived)
        if (Input.GetButtonDown("Fire1") && animator.GetCurrentAnimatorStateInfo(0).IsName("Armature_Idle_Sword_And_Shield"))
        {
            animator.SetTrigger("AttackTrigger");
        }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

}
