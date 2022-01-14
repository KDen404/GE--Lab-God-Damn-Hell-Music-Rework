using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotalEnemyCount : MonoBehaviour
{
    private List<Transform> totalEnemyCount;

    
    void Update()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            if (child.tag == "Room")
            {
                for (int j = 0; j < child.childCount; j++)
                {
                    Transform child2 = child.GetChild(j);

                    if (child2.tag == "Enemy")
                    {
                        totalEnemyCount.Add(child2);
                    }
                }
            }

            totalEnemyCount.RemoveAll(GameObject => GameObject == null);
        }
    }
}
