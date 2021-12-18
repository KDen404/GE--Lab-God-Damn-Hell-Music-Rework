using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream:God Damn Hell/Assets/Scripts/Enemy/EnemyMovement.cs
/*current Problems/ To Fix:

Important:
rotate enemy, instead of lookat?   abrupt change
Death animation
destroy after a certain time


=======
public class DemonFighterMovement : MonoBehaviour
{
    private Stats demonFighterStats;
    private GameObject player;
    private float aggroRange;
    private NavMeshAgent agent;
    private DemonFighterAnimations demonFighterAnimations;
>>>>>>> Stashed changes:God Damn Hell/Assets/Scripts/Enemy/DemonFighter/DemonFighterMovement.cs

Optional: 
gets the position in childs, of the parent
player = not the name but GetComponent

*/

public class EnemyMovement : MonoBehaviour
{
    public EnemyStats enemystats;

    private GameObject player;
    
    private float enemySpeed = 0;
    private float aggroRange = 0;

    //test
    public bool activated = false;
    private bool facesPlayer = true;
    
    //public int positionInChilds;

    private void Start()
    {
        player = GameObject.Find("Player Object");
<<<<<<< Updated upstream:God Damn Hell/Assets/Scripts/Enemy/EnemyMovement.cs
        enemySpeed = enemystats.movementspeed;
        aggroRange = enemystats.aggroRange;
=======
        agent = GetComponent<NavMeshAgent>();
        demonFighterStats = gameObject.GetComponent<Stats>();
        demonFighterAnimations = GetComponent<DemonFighterAnimations>();

        agent.speed = demonFighterStats.movementspeed;
        aggroRange = demonFighterStats.aggroRange;
>>>>>>> Stashed changes:God Damn Hell/Assets/Scripts/Enemy/DemonFighter/DemonFighterMovement.cs
    }

    private void FixedUpdate()
    {
<<<<<<< Updated upstream:God Damn Hell/Assets/Scripts/Enemy/EnemyMovement.cs
        movement();
        death();


=======
        //movement();
        navmovement();
>>>>>>> Stashed changes:God Damn Hell/Assets/Scripts/Enemy/DemonFighter/DemonFighterMovement.cs
    }


    private void movement()
    {
        if (activated && demonFighterAnimations.isDead == false)
        {
<<<<<<< Updated upstream:God Damn Hell/Assets/Scripts/Enemy/EnemyMovement.cs
            if (facesPlayer)
            {
                transform.LookAt(new Vector3(player.transform.position.x,this.transform.position.y, player.transform.position.z));
                transform.position += transform.forward * Time.deltaTime * enemySpeed;
            }
            else
            {
                //rotate to Player over time
=======
            agent.destination = player.transform.position;
            agent.speed = 5f;

            if (Vector3.Distance(transform.position, player.transform.position) <= 4)
            {
                demonFighterAnimations.inAttackRange = true;
            }
            else
            {
                demonFighterAnimations.inAttackRange = false;
>>>>>>> Stashed changes:God Damn Hell/Assets/Scripts/Enemy/DemonFighter/DemonFighterMovement.cs
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

<<<<<<< Updated upstream:God Damn Hell/Assets/Scripts/Enemy/EnemyMovement.cs
    private void death()
    {
        if(enemystats.healthPoints == 0)
        {
            //deathanimation
            

            GetComponentInParent<AlarmOtherEnemies>().activityHasChanged = true;
            Destroy(gameObject);
        }
    }

=======
>>>>>>> Stashed changes:God Damn Hell/Assets/Scripts/Enemy/DemonFighter/DemonFighterMovement.cs


}
