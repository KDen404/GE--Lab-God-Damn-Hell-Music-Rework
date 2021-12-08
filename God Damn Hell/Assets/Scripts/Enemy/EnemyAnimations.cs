using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    private Animator animator;
    private GameObject player;
    private EnemyStats enemyStats;

    private int tempHealthPoints;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        enemyStats = GetComponent<EnemyStats>();
        tempHealthPoints = enemyStats.healthPoints;
    }

    private void Update()
    {
        Run();
        Attack();
        Die();
        GetHit();
    }

    public virtual void Run()
    {

    }

    public virtual void Attack()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 7)
        {
            animator.SetTrigger("AttackTrigger");
        }
    }


    public virtual void Die()
    {
        if (enemyStats.healthPoints < 0)
        {
            if (!animator.GetCurrentAnimatorStateInfo(1).IsName("Die"))
            {
                animator.SetTrigger("IsDead");
            }
        }
    }

    public virtual void GetHit()
    {
        if (tempHealthPoints != enemyStats.healthPoints)
        {
            animator.SetTrigger("GetHit");
            tempHealthPoints = enemyStats.healthPoints;
        }
    }
}
