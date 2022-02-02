using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// Could have been a child class to avoid the copy paste anti-pattern
public class DemonFighterAnimations : MonoBehaviour
{
    // General fields
    public Animator animator;
    private Stats demonFighterStats;
    private DemonFighterMovement demonFighterMovement;

    // GetHit
    private int tempHealthPoints;

    public int knockbackStrength = 4;

    // Attack
    public bool inAttackRange = false;
    public Collider leftHandCollider;
    public Collider rightHandCollider;

    // Die
    private Collider demonFighterCollider;

    // IdleWalk
    private float randIdleWaitTime;
    private float timeCount;
    private NavMeshAgent agent;

    private void Start()
    {
        demonFighterStats = GetComponent<Stats>();
        demonFighterMovement = GetComponent<DemonFighterMovement>();
        tempHealthPoints = GetComponent<Stats>().healthPoints;
        demonFighterCollider = GetComponent<BoxCollider>();
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
        if (demonFighterMovement.activated == true)
        {
            animator.SetFloat("WalkRunFloat", 1f);
        }
        else
        {
            animator.SetFloat("WalkRunFloat", 0f);
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
        if (demonFighterStats.healthPoints <= 0)
        {
            // Didnt work as a trigger, therefore Im checking if the object is already in the animation
            if (!animator.GetCurrentAnimatorStateInfo(3).IsName("Death"))
            {
                animator.SetBool("IsDeadBool", true);
                demonFighterMovement.enabled = false;
                demonFighterCollider.enabled = false;
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
        if (tempHealthPoints != demonFighterStats.healthPoints)
        {
            animator.SetTrigger("GetHitTrigger");
            tempHealthPoints = demonFighterStats.healthPoints;
        }
    }

    // Time variable counts up and another variable calculates a random number
    // If time > random number, calculate a new location nearby and move there
    private void IdleWalk()
    {
        if (demonFighterMovement.activated == false)
        {
            if (timeCount >= randIdleWaitTime)
            {
                agent.speed = demonFighterStats.movementspeed;
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
