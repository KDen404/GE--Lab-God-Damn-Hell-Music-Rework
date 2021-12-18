using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DemonFighterMovement : MonoBehaviour
{
    private Stats demonFighterStats;
    private GameObject player;
    private float aggroRange;
    private NavMeshAgent agent;
    private DemonFighterAnimations demonFighterAnimations;
    private bool activated;

    private void Start()
    {
        player = GameObject.Find("Player Object");
        enemySpeed = demonFighterStats.movementspeed;
        aggroRange = demonFighterStats.aggroRange;
        activated = GetComponent<Stats>.activated;

        agent = GetComponent<NavMeshAgent>();
        demonFighterStats = gameObject.GetComponent<Stats>();
        demonFighterAnimations = GetComponent<DemonFighterAnimations>();

        agent.speed = demonFighterStats.movementspeed;
        aggroRange = demonFighterStats.aggroRange;
    }

    private void FixedUpdate()
    {
        navmovement();
    }


    private void navmovement()
    {
        if (activated && demonFighterAnimations.isDead == false)
        {
            if (facesPlayer)
            {
                transform.LookAt(new Vector3(player.transform.position.x,this.transform.position.y, player.transform.position.z));
                transform.position += transform.forward * Time.deltaTime * enemySpeed;
            }
            else
            {
                //rotate to Player over time

            agent.destination = player.transform.position;
            agent.speed = 5f;

            if (Vector3.Distance(transform.position, player.transform.position) <= 4)
            {
                demonFighterAnimations.inAttackRange = true;
            }
            else
            {
                demonFighterAnimations.inAttackRange = false;
            }
        }
        else
        {                                           
            if ((Vector3.Distance(transform.position, player.transform.position) <= aggroRange))    //if the Player is in a certain distance
            {
                activated = true;
                GetComponentInParent<AlarmOtherEnemies>().activityHasChanged = true;
                
            }
        }
    }
    }


//    if (Vector3.Distance(transform.position, player.transform.position) <= 4)
//            {
//                demonFighterAnimations.inAttackRange = true;
//            }
//            else
//{
//    demonFighterAnimations.inAttackRange = false;
//}