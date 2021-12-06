using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*current Problems/ To Fix:

Important:
rotate enemy, instead of lookat?   abrupt change
Death animation
destroy after a certain time



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
        enemySpeed = enemystats.movementspeed;
        aggroRange = enemystats.aggroRange;
    }

    private void FixedUpdate()
    {
        movement();
        death();


    }


    private void movement()
    {
        if (activated)
        {
            if (facesPlayer)
            {
                transform.LookAt(new Vector3(player.transform.position.x,this.transform.position.y, player.transform.position.z));
                transform.position += transform.forward * Time.deltaTime * enemySpeed;
            }
            else
            {
                //rotate to Player over time
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

    private void death()
    {
        if(enemystats.healthPoints == 0)
        {
            //deathanimation
            

            GetComponentInParent<AlarmOtherEnemies>().activityHasChanged = true;
            Destroy(gameObject);
        }
    }



}
