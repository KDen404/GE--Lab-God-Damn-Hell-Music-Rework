using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Could have been a child class to avoid the copy paste anti-pattern
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
        timeCount += Time.deltaTime;

        Run();
        Attack();
        Die();
        GetHit();
        IdleWalk();
    }

    // Call the run animation if the enemy spotted the player
    private void Run()
    {
        if (demonSpearMovement.activated == true)
        {
            agent.speed = runSpeed;
            animator.SetFloat("WalkRunFloat", 1f);
        }
    }

    // If the player is close enough start attacking
    private void Attack()
    {
        if (inAttackRange == true)
        {
            animator.SetFloat("AttackFloat", Random.Range(0f, 1f));
        }
        else
        {
            animator.SetFloat("AttackFloat", 0f);
        }
    }

    // Play animation when dead
    private void Die()
    {
        if (demonSpearStats.healthPoints <= 0)
        {
            // Didnt work as a trigger, therefore Im checking if the object is already in the animation
            if (!animator.GetCurrentAnimatorStateInfo(3).IsName("Death"))
            {
                animator.SetBool("IsDeadBool", true);
                demonSpearMovement.enabled = false;
                demonSpearCollider.enabled = false;
                agent.enabled = false;
                StartCoroutine(DieCoroutine());
            }
        }
    }

    // Destroy the object after a certain time after it died
    private IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        GetComponentInParent<AlarmOtherEnemiesRework>().activityHasChanged = true;
        Destroy(gameObject);
    }

    // Checks if the mage was hit and if so, play the trigger
    private void GetHit()
    {
        if (tempHealthPoints != demonSpearStats.healthPoints)
        {
            animator.SetTrigger("GetHitTrigger");
            tempHealthPoints = demonSpearStats.healthPoints;
        }
    }

    // Time variable counts up and another variable calculates a random number
    // If time > random number, calculate a new location nearby and move there
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
            }
            else
            {
                animator.SetFloat("WalkRunFloat", 0f);
            }
        }
    }
}
