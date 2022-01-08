using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracker : MonoBehaviour
{
    public List<Transform> enemies;
    public bool triggered = false;
    public GateLogic gatelogic;


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
