using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonSpearHit : MonoBehaviour
{
    public BoxCollider spearCollider;

    public virtual void OnTriggerEnter(Collider other)
    {
        // Collider is on the enemies spear, code below only works if the target hit is the player or the shield
        if (other.gameObject.transform.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().currentHealthPoints -= 4;
        }
        else if (other.gameObject.transform.tag == "Shield")
        {
            spearCollider.enabled = false;
        }
    }
}
