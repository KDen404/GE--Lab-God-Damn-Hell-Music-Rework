using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemonMageAnimations : MonoBehaviour
{
    // General fields
    public Animator animator;
    private Stats demonMageStats;
    private DemonMageMovement demonMageMovement;

    // GetHit
    private int tempHealthPoints;
    private float pushbackTime = 1;
    private bool getsPushedBack = false;
    public int knockbackStrength = 4;

    // Attack
    public bool inAttackRange = false;
    private float random;
    public GameObject pyroballEmpty;
    public GameObject fireballEmpty;
    public GameObject pyroball;
    public GameObject fireball;
    private GameObject player;

    // Die
    private float timeDead;
    private bool isDead;
    private Collider demonMageCollider;

    // IdleWalk
    private float randIdleWaitTime;
    private float timeCount;
    private NavMeshAgent agent;

    private void Start()
    {
        demonMageStats = GetComponent<Stats>();
        demonMageMovement = GetComponent<DemonMageMovement>();
        tempHealthPoints = GetComponent<Stats>().healthPoints;
        demonMageCollider = GetComponent<BoxCollider>();
        randIdleWaitTime = Random.Range(2f, 8f);
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
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
        if (demonMageMovement.activated == true)
        {
            animator.SetFloat("WalkRunFloat", 1f);
        }
    }

    private void Attack()
    {
        // If the player is close enough start attacking
        if (inAttackRange == true)
        {
            animator.SetFloat("AttackFloat", random = Random.Range(0f, 1f));
            StartCoroutine(DemonMageCast());
        }
        else
        {
            random = 0f;
        }
    }

    private IEnumerator DemonMageCast()
    {
        yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(1).length);

        if (random < 0.2f)
        {
            GameObject newPyroball;
            newPyroball = Instantiate(pyroball, pyroballEmpty.transform);
            newPyroball.transform.position = Vector3.MoveTowards(newPyroball.transform.position, player.transform.position, 100f);
        }
        else
        {
            GameObject newFireball;
            newFireball = Instantiate(fireball, fireballEmpty.transform);
            newFireball.transform.position = Vector3.MoveTowards(newFireball.transform.position, player.transform.position, 100f);
        }
    }

    private void Die()
    {
        // Play animation when dead
        if (demonMageStats.healthPoints <= 0)
        {
            if (!animator.GetCurrentAnimatorStateInfo(3).IsName("Death"))
            {
                animator.SetBool("IsDeadBool", true);
                GetComponentInParent<AlarmOtherEnemies>().activityHasChanged = true;
                isDead = true;
                demonMageMovement.enabled = false;
                demonMageCollider.enabled = false;
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
        if (tempHealthPoints != demonMageStats.healthPoints)
        {
            animator.SetTrigger("GetHitTrigger");
            getsPushedBack = true;
            pushbackTime = 0f;
            tempHealthPoints = demonMageStats.healthPoints;
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
        if (demonMageMovement.activated == false)
        {
            if (timeCount >= randIdleWaitTime)
            {
                agent.speed = demonMageStats.movementspeed;
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
