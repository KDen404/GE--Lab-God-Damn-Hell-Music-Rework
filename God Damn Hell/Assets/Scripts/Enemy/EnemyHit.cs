using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public PlayerStats playerStats;

    public virtual void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.transform.parent.tag == "Player")
        {
            playerStats.healthPoints--;
        }
    }
}
