using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    private Transform enemy;
    private float lastHit;

    public int tempKnockbackStrength = 13;

    private void Update()
    {
        lastHit += Time.deltaTime;
    }

    private  void OnTriggerEnter(Collider other)
    {
        // lastHit so the player cant hit the enemy more than once in one animation turn
        // and checking if the player is actually attacking or else the weapon can damage just by colliding with an enemy outside any animation
        if (lastHit >= 1f && other.gameObject.transform.tag == "Enemy" && animator.GetCurrentAnimatorStateInfo(2).IsName("Attack"))
        {
            other.gameObject.transform.GetComponent<Stats>().healthPoints--;
            enemy = other.transform;
            StartCoroutine(AddForceSimulation(enemy));
            lastHit = 0;
        }
    }

    private IEnumerator AddForceSimulation(Transform enemy)
    {
        enemy.position += -enemy.transform.forward * tempKnockbackStrength * Time.deltaTime;
        yield return new WaitForSeconds(0.5f);
        yield break;
    }


    //public virtual void OnCollisionEnter(Collision other)
    //{
    //    if (other.gameObject.transform.parent.tag == "Enemy" && animator.GetCurrentAnimatorStateInfo(1).IsName("Attack"))
    //    {
    //        // <EnemyStats> should just be stats once actual enemies exist
    //        other.gameObject.transform.parent.GetComponent<EnemyStats>().healthPoints--;
    //        Debug.Log("Hit the enemy!");
    //        //other.gameObject.GetComponent<Rigidbody>().AddForce(-other.transform.forward * 100, ForceMode.Impulse);
    //    }
    //}
}
