using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    public List<Transform> enemies;
    public bool triggered = false;
    public GateLogic gatelogic;

    // If the entrance collider gets triggered collect all enemies in a list
    // If the list is empty open all the gates
    // Better solution would have been to add this script to the object with AddComponent<>() and then collect the enemies once
    // in the Start function so the update only has to check for nullpointers
    private void Update()
    {
        if (triggered)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);

                if (child.tag == "Enemy" && !enemies.Contains(child))
                {
                    enemies.Add(child);
                }

                enemies.RemoveAll(GameObject => GameObject == null);
            }

            if (enemies.Count == 0)
            {
                Debug.Log("Open Gates");
                gatelogic.OpenGates();
                triggered = false;
            }
        }
    }
}
