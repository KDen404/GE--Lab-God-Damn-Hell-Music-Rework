using UnityEngine;
using UnityEngine.AI;

public class DemonFighterMovement : MonoBehaviour
{
    private Stats demonFighterStats;
    private DemonFighterAnimations demonFighterAnimations;
    private GameObject player;
    private float aggroRange;
    private NavMeshAgent agent;
    public bool activated = false;
    public int demonFighterRunSpeed = 6;


    private void Start()
    {
        player = GameObject.Find("Player Object");
        agent = GetComponent<NavMeshAgent>();
        demonFighterStats = GetComponent<Stats>();
        demonFighterAnimations = GetComponent<DemonFighterAnimations>();
        activated = demonFighterStats.activated;

        agent.speed = demonFighterStats.movementspeed;
        aggroRange = demonFighterStats.aggroRange;
    }

    private void FixedUpdate()
    {
        navmovement();
    }


    private void navmovement()
    {
        if (demonFighterStats.activated)
        {
            agent.destination = player.transform.position;
            agent.speed = demonFighterRunSpeed;

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
                if ((Vector3.Angle(transform.forward, player.transform.position - transform.position) <= 40) // if the player is in the view field of the enemy
                    || (Vector3.Distance(transform.position, player.transform.position) <= aggroRange/2))      // or very close
                {
                    demonFighterStats.activated = true;
                    activated = true;
                    GetComponentInParent<AlarmOtherEnemiesRework>().activityHasChanged = true;
                }
                
            }
        }
    }
}