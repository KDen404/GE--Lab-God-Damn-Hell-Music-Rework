using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonSpearAnimations : MonoBehaviour
{
    // General fields
    public Animator animator;
    private Stats demonSpearStats;
    private DemonSpearMovement demonSpearMovement;

    // Attack
    public bool inAttackRange = false;


    void Start()
    {
        demonSpearStats = GetComponent<Stats>();
        demonSpearMovement = GetComponent<DemonSpearMovement>();
    }

    void Update()
    {
        Run();
        Attack();
        Die();
        GetHit();
        IdleWalk();
    }

    private void Run()
    {
        if (demonSpearMovement.activated == true)
        {
            animator.SetFloat("WalkRunFloat", 1);
        }
    }

    private void Attack()
    {
        if (inAttackRange == true)
        {
            animator.SetFloat("AttackFloat", Random.Range(0f, 1f));
        }


    }

    private void Die()
    {

    }

    private void GetHit()
    {

    }

    private void IdleWalk()
    {

    }
}
