using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemonMageMovement : MonoBehaviour
{
    private Stats demonMageStats;
    private DemonMageAnimations demonMageAnimations;
    private GameObject player;
    private float aggroRange;
    private NavMeshAgent agent;
    public bool activated = false;
    public int demonMageRunSpeed = 6;


    private void Start()
    {
        player = GameObject.Find("Player Object");
        agent = GetComponent<NavMeshAgent>();
        demonMageStats = GetComponent<Stats>();
        demonMageAnimations = GetComponent<DemonMageAnimations>();
        activated = demonMageStats.activated;

        agent.speed = demonMageStats.movementspeed;
        aggroRange = demonMageStats.aggroRange;
    }

    private void FixedUpdate()
    {
        navmovement();
    }


    private void navmovement()
    {
        if (activated)
        {
            agent.speed = demonMageRunSpeed;
            agent.destination = player.transform.position;

            if (Vector3.Distance(transform.position, player.transform.position) <= 4)
            {
                demonMageAnimations.inAttackRange = true;
            }
            else
            {
                demonMageAnimations.inAttackRange = false;
            }
        }
        else
        {
            if ((Vector3.Distance(transform.position, player.transform.position) <= aggroRange))    //if the Player is in a certain distance
            {
                if ((Vector3.Angle(transform.forward, player.transform.position - transform.position) <= 40) //if the player is in the view field of the enemy
                    || (Vector3.Distance(transform.position, player.transform.position) <= aggroRange / 2))  // or very close
                {
                    activated = true;
                    GetComponentInParent<AlarmOtherEnemies>().activityHasChanged = true;
                }
            }
        }
    }
}
