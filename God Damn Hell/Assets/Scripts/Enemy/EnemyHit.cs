using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    public virtual void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.transform.parent.tag == "Player")
        {
            playerStats.healthPoints--;
        }
    }
}
