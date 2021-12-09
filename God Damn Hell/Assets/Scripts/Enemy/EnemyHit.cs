using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    public Animator animator;
    float lastHit = 0;

    private void Update()
    {
        lastHit += Time.deltaTime;
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (lastHit >= 1f && other.gameObject.transform.tag == "Player" && (animator.GetCurrentAnimatorStateInfo(1).IsName("AttackLeft") || animator.GetCurrentAnimatorStateInfo(1).IsName("AttackRight")))
        {
            other.gameObject.GetComponent<PlayerStats>().healthPoints--;
            lastHit = 0;
        }
    }
}
