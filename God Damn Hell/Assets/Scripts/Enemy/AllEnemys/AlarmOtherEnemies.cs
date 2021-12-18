using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
this Script is for the purpose of alarming other enemies,
if an enemy in Range has already seen a player object
*/


/* To Do
Fixed Update testen

enemyNumber gets smaller, if enemy dies;

each enemy has own alarm range? 

*/

public class AlarmOtherEnemies : MonoBehaviour
{
    private int enemyNumber;
    private int alarmEnemyRange = 15;
    private List<int> listOfActivatedEnemys= new List<int>();    //list of all activated enemys
    private List<int> notActivatedEnemyList = new List<int>();   //list of all unactive enemys

    private int activeLength = 0;               //number of activated enemys
    private int deactivatedLength = 0;

    public bool activityHasChanged = true;      //if a new Enemy has been set active ->  updates the lists of activated/deactivated enemys


    private void FixedUpdate()       
    {

        if (activityHasChanged)
        {
            updateActivity();       
        }
        if(deactivatedLength != 0)
        {  
            alarmOtherEnemys();
        }
       
    }

    private void alarmOtherEnemys() // Looks if any deactivated enemys are in range of an activated enemy, if so it activates that enemy.
    {
        
        for(int activEnemy = 0; activEnemy< activeLength; activEnemy++)
        {
            for (int unactiveEnemy = 0; unactiveEnemy < deactivatedLength; unactiveEnemy++)
            {
                if (Vector3.Distance(transform.GetChild(listOfActivatedEnemys[activEnemy]).position, transform.GetChild(notActivatedEnemyList[unactiveEnemy]).position) <= alarmEnemyRange)
                {
                    activityHasChanged = true;
                    transform.GetChild(notActivatedEnemyList[unactiveEnemy]).GetComponentInChildren<Stats>().activated = true;
                }
            }
        }          
       
    }

    private void updateActivity()   // updates the lists of activated/deactivated enemys
    {
        enemyNumber = transform.childCount;
        activityHasChanged = false;
        for (int i = activeLength - 1; i >= 0; i--){
            listOfActivatedEnemys.Remove(i);
        }
        for (int i = deactivatedLength - 1; i >= 0; i--)
        {
            notActivatedEnemyList.Remove(i);
        }

        activeLength = 0;
        deactivatedLength = 0;

        for (int i = 0; i < enemyNumber; i++)
        {
            //transform.GetChild(i).GetComponentInChildren<EnemyMovement>().positionInChilds = i;     // gives each child their position

            if (transform.GetChild(i).GetComponentInChildren<Stats>().activated)
            {
                listOfActivatedEnemys.Add(i);
                activeLength += 1;
            }
            else
            {
                notActivatedEnemyList.Add(i);
                deactivatedLength += 1;
            }
        }

    }
}
