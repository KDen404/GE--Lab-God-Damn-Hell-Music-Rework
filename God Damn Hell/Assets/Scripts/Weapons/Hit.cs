using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public Animator animator;
    public GameObject player;
    private Transform enemy;
    private float lastHit;
    private float addForceTime = 1f;

    public int tempKnockbackStrength = 10;

    private void Update()
    {
        lastHit += Time.deltaTime;
        addForceTime += Time.deltaTime;

        if (addForceTime <= 0.5f)
        {
            enemy.position += -enemy.transform.forward * tempKnockbackStrength * Time.deltaTime;
        }
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (lastHit >= 1f && other.gameObject.transform.tag == "Enemy" && animator.GetCurrentAnimatorStateInfo(2).IsName("Attack"))
        {
            other.gameObject.transform.GetComponent<Stats>().healthPoints--;
            Vector3 direction = (other.transform.position - player.transform.position);
            addForceTime = 0;
            enemy = other.transform;

            lastHit = 0;
        }
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
