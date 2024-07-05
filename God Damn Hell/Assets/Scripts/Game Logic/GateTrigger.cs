using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateTrigger : MonoBehaviour
{
    public GateLogic gatelogic;
    private MusicManager _musicManager;

    // Close all the gates in the array when the entrance collider gets triggered
    // Better solution would have been with AddComponent<>() to avoid constant checks of the bool
    private void Start()
    {
        _musicManager = GameObject.Find("WwiseGlobal").GetComponent<MusicManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _musicManager.PlayerTriggeredGate();
            gatelogic.CloseGates();
            transform.parent.transform.GetComponent<EnemyTracker>().triggered = true;
            Destroy(gameObject);
        }
    }
}
