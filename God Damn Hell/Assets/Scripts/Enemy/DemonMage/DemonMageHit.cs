using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonMageHit : MonoBehaviour
{
    public Animator animator;
    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().currentHealthPoints--; // Needs an actual number later on
            Destroy(gameObject);
            Debug.Log("Destroy ball");
        }

        Debug.Log("Player not hit");
    }
}
