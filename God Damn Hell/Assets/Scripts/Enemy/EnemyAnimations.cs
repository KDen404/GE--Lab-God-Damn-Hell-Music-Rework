using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour
{
    // General variables
    public Animator animator;
    private GameObject player;
    private EnemyStats enemyStats;

    // HP
    private int tempHealthPoints;

    // Attack
    private float timeSinceLastAttack;
    private float randFloat;

    private void Start()
    {
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
        timeSinceLastAttack += Time.deltaTime;

        if (Vector3.Distance(transform.position, player.transform.position) < 3 && timeSinceLastAttack > 1.5f)
        {
            randFloat = Random.Range(0f, 1f);
            animator.SetFloat("AttackFloat", randFloat);
            timeSinceLastAttack = 0f;
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
