using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public Animator animator;
    public Transform player;
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

            enemy.transform.position += (enemy.position - player.position) * tempKnockbackStrength * Time.deltaTime;

            if (countPushBack >= 0.5f)
            {
                enemyHit = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Only works if the other object is an enemy
        if (other.gameObject.transform.tag == "Enemy")
        {
            other.gameObject.transform.GetComponent<Stats>().healthPoints--;
            enemy = other.transform;
            countPushBack = 0;
            enemyHit = true;
        }
    }
}
