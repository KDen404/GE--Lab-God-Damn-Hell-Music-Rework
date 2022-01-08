using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    public GateLogic gatelogic;

    private void OnTriggerEnter(Collider other)
    {
        gatelogic.CloseGates();
        transform.parent.transform.GetComponent<EnemyTracker>().triggered = true;
        Destroy(gameObject);
    }
}
