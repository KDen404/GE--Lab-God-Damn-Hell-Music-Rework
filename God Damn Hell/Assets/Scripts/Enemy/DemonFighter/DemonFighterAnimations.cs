using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemonFighterAnimations : MonoBehaviour
{
    // General fields
    public Animator animator;
    private Stats demonFighterStats;
    private DemonFighterMovement demonFighterMovement;

    // GetHit
    private int tempHealthPoints;
    private float pushbackTime = 1;
    private bool getsPushedBack = false;
    public int knockbackStrength = 4;

    // Attack
    public bool inAttackRange = false;
    public Collider leftHandCollider;
    public Collider rightHandCollider;

    // Die
    private float timeDead;
    private bool isDead;
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
        pushbackTime += Time.deltaTime;

        Run();
        Attack();
        Die();
        GetHit();
        IdleWalk();
    }

    private void Run()
    {
        if (demonFighterMovement.activated == true)
        {
            animator.SetFloat("WalkRunFloat", 1f);
        }
    }

    private void Attack()
    {
        // If the player is close enough start attacking
        if (inAttackRange == true)
        {
            animator.SetFloat("AttackFloat", Random.Range(0f, 1f));
        }

        // Activates / deactivates the collider
        if (animator.GetCurrentAnimatorStateInfo(1).IsName("AttackLeft"))
        {
            leftHandCollider.enabled = true;
        }
        else
        {
            leftHandCollider.enabled = false;
        }

        if (animator.GetCurrentAnimatorStateInfo(1).IsName("AttackRight"))
        {
            rightHandCollider.enabled = true;
        }
        else
        {
            rightHandCollider.enabled = false;
        }
    }


    private void Die()
    {
        // Play animation when dead
        if (demonFighterStats.healthPoints <= 0)
        {
            if (!animator.GetCurrentAnimatorStateInfo(3).IsName("Death"))
            {
                animator.SetBool("IsDeadBool", true);
                GetComponentInParent<AlarmOtherEnemies>().activityHasChanged = true;
                isDead = true;
                demonFighterMovement.enabled = false;
                demonFighterCollider.enabled = false;
            }
        }

        if (isDead == true)
        {
            timeDead += Time.deltaTime;

            // Disable animator after 1.5s so it cant attack anymore
            if (timeDead > 1.5f)
            {
                animator.enabled = false;
            }

            // Despawn after 5s
            if (timeDead >= 5)
            {
                Destroy(gameObject);
            }
        }
    }

    private void GetHit()
    {
        if (tempHealthPoints != demonFighterStats.healthPoints)
        {
            animator.SetTrigger("GetHitTrigger");
            getsPushedBack = true;
            pushbackTime = 0f;
            tempHealthPoints = demonFighterStats.healthPoints;
        }

        if (getsPushedBack == true && pushbackTime <= 0.5f)
        {
            transform.position += -transform.forward * knockbackStrength * Time.deltaTime;
        }
        else
        {
            getsPushedBack = false;
        }
    }

    private void IdleWalk()
    {
        if (timeCount >= randIdleWaitTime && demonFighterMovement.activated == false)
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
