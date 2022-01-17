using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    private Transform enemy;
    private float countPushBack;
    private bool enemyHit = false;

    private float tempKnockbackStrength = 1.5f;

    private void Update()
    {

        // Currently only one enemy of all enemies hit gets knockbacked, can be fixed by using arrays
        if (enemyHit == true)
        {
            countPushBack += Time.deltaTime;
            // Should be a vector for a proper knockback simulation

            enemy.transform.position += (enemy.transform.position - player.transform.position) * tempKnockbackStrength * Time.deltaTime;

            if (countPushBack >= 0.5f)
            {
                enemyHit = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // lastHit so the player cant hit the enemy more than once in one animation turn
        // and checking if the player is actually attacking or else the weapon can damage just by colliding with an enemy outside any animation
        if (other.gameObject.transform.tag == "Enemy")
        {
            other.gameObject.transform.GetComponent<Stats>().healthPoints--;
            enemy = other.transform;
            countPushBack = 0;
            enemyHit = true;
        }
    }
}
