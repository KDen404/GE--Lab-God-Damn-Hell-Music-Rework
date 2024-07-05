using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonMageHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().Hit(4);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
