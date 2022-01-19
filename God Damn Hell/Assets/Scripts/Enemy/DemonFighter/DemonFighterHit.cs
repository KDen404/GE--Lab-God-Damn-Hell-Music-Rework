using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonFighterHit : MonoBehaviour
{
    public BoxCollider leftHandCollider;
    public BoxCollider rightHandCollider;

    private void OnTriggerEnter(Collider other)
    {
        // Colliders are on the enemies hands, code below only works if the target hit is the player or the shield
        if (other.gameObject.transform.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().currentHealthPoints -= 3;
        }
        else if (other.gameObject.transform.tag == "Shield")
        {
            leftHandCollider.enabled = false;
            rightHandCollider.enabled = false;
        }
    }
}
