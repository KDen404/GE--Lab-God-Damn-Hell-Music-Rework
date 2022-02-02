using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    public GateLogic gatelogic;

    // Close all the gates in the array when the entrance collider gets triggered
    // Better solution would have been with AddComponent<>() to avoid constant checks of the bool
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gatelogic.CloseGates();
            transform.parent.transform.GetComponent<EnemyTracker>().triggered = true;
            Destroy(gameObject);
        }
    }
}
