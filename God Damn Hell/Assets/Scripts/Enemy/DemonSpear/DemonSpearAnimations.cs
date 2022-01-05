using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemonSpearAnimations : MonoBehaviour
{
    // General fields
    public Animator animator;
    private Stats demonSpearStats;
    private DemonSpearMovement demonSpearMovement;

    // Run
    public int runSpeed = 6;

    // Attack
    public bool inAttackRange = false;
    public Collider spearCollider;
    private Collider demonSpearCollider;

    // GetHit
    private int tempHealthPoints;
    public int knockbackStrength = 5;

    // IdleWalk
    private float timeCount;
    private float randIdleWaitTime;
    private NavMeshAgent agent;

    private void Start()
    {
        demonSpearStats = GetComponent<Stats>();
        demonSpearMovement = GetComponent<DemonSpearMovement>();
        demonSpearCollider = GetComponent<BoxCollider>();

        tempHealthPoints = demonSpearStats.healthPoints;

        randIdleWaitTime = Random.Range(2f, 8f);
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
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
            agent.speed = runSpeed;
            animator.SetFloat("WalkRunFloat", 1f);
            AkSoundEngine.PostEvent("DemonSpearRun", gameObject);
        }
    }

    private void Attack()
    {
        if (inAttackRange == true)
        {
            animator.SetFloat("AttackFloat", Random.Range(0f, 1f));
            AkSoundEngine.PostEvent("SpearSwing", gameObject);
        }

        // Activates / deactivates the collider
        if (animator.GetCurrentAnimatorStateInfo(1).IsName("Attack1") || animator.GetCurrentAnimatorStateInfo(1).IsName("Attack2"))
        {
            spearCollider.enabled = true;
        }
        else
        {
            spearCollider.enabled = false;
        }
    }

    private void Die()
    {
        // Play animation when dead
        if (demonSpearStats.healthPoints <= 0)
        {
            if (!animator.GetCurrentAnimatorStateInfo(3).IsName("Death"))
            {
                animator.SetBool("IsDeadBool", true);
                AkSoundEngine.PostEvent("DemonSpearDeath", gameObject);
                GetComponentInParent<AlarmOtherEnemies>().activityHasChanged = true;
                demonSpearMovement.enabled = false;
                demonSpearCollider.enabled = false;
                StartCoroutine(DieCoroutine());
            }
        }
    }

    private IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        animator.enabled = false;
        yield return new WaitForSeconds(3.5f);
        Destroy(gameObject);
    }

    private void GetHit()
    {
        if (tempHealthPoints != demonSpearStats.healthPoints)
        {
            animator.SetTrigger("GetHitTrigger");
            AkSoundEngine.PostEvent("DemonSpearGotHit", gameObject);
            tempHealthPoints = demonSpearStats.healthPoints;
        }
    }

    private void IdleWalk()
    {
        if (demonSpearMovement.activated == false)
        {
            if (timeCount >= randIdleWaitTime)
            {
                agent.speed = demonSpearStats.movementspeed;
                Vector3 newDestination = new Vector3(Random.Range(-8, 8), 0f, Random.Range(-8, 8)) + transform.position;
                agent.destination = newDestination;
                randIdleWaitTime = Random.Range(2f, 8f);
                timeCount = 0f;
            }

            if (agent.remainingDistance >= 0.1)
            {
                animator.SetFloat("WalkRunFloat", 0.5f);
                AkSoundEngine.PostEvent("DemonSpearWalk", gameObject);
            }
            else
            {
                animator.SetFloat("WalkRunFloat", 0f);
            }
        }
    }
}
