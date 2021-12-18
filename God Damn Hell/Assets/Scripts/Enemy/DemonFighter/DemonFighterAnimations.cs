using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemonFighterAnimations : MonoBehaviour
{
    // General variables
    public Animator animator;
    private GameObject player;
    private Stats demonFighterStats;
    private DemonFighterMovement demonFighterMovement;

    // GetHit
    private int tempHealthPoints;
    private float pushbackTime = 1;
    private bool getsPushedBack = false;
    public int knockbackStrength = 4;

    // Attack
    public bool inAttackRange = false;
    private float randFloat;
    public GameObject leftHand;
    public GameObject rightHand;
    private Collider leftHandCollider;
    private Collider rightHandCollider;

    // Die
    private float timeDead;
    public bool isDead;

    // IdleWalk
    private float randIdleWaitTime;
    private float timeCount;
    private NavMeshAgent agent;
    private bool destinationReached = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        demonFighterStats = GetComponent<Stats>();
        demonFighterMovement = GetComponent<DemonFighterMovement>();

        tempHealthPoints = GetComponent<Stats>().healthPoints;

        leftHandCollider = leftHand.GetComponent<BoxCollider>();
        rightHandCollider = rightHand.GetComponent<BoxCollider>();

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

    public virtual void Run()
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

    public virtual void Attack()
    {
        // If the player is close enough start attacking
        if (inAttackRange == true)
        {
            randFloat = Random.Range(0f, 1f);
            animator.SetFloat("AttackFloat", randFloat);
        }
        else
        {
            animator.SetFloat("AttackFloat", 0f);
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


    public virtual void Die()
    {
        // Play animation when dead
        if (demonFighterStats.healthPoints <= 0)
        {
            if (!animator.GetCurrentAnimatorStateInfo(3).IsName("Death"))
            {
                animator.SetBool("IsDeadBool", true);
                GetComponentInParent<AlarmOtherEnemies>().activityHasChanged = true;
                isDead = true;
            }
        }

        if (animator.GetBool("IsDeadBool") == true)
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

    public virtual void GetHit()
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

    public virtual void IdleWalk()
    {
        if (timeCount >= randIdleWaitTime && demonFighterMovement.activated == false)
        {
            agent.speed = 3f;
            Vector3 newDestination = transform.position + new Vector3(Random.Range(-8, 8), 0f, Random.Range(-8, 8));
            agent.destination = newDestination;
            randIdleWaitTime = Random.Range(2f, 8f);
            timeCount = 0f;
            destinationReached = false;

            if (destinationReached == false)
            {
                animator.SetFloat("WalkRunFloat", 0.5f);
            }
            else if (agent.destination == newDestination)
            {
                animator.SetFloat("WalkRunFloat", 0f);
                destinationReached = true;
            }
        }
    }
}
