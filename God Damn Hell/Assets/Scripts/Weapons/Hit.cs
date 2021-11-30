using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public virtual void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.transform.parent.tag == "Enemy")
        {
            // <EnemyStats> should just be stats once actual enemies exist
            other.gameObject.transform.parent.GetComponent<EnemyStats>().healthPoints--;
            Debug.Log("Hit the enemy!");
        }
    }
}
