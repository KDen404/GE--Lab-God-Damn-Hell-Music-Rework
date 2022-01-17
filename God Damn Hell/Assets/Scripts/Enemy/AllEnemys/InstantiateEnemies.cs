using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemies : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    public GameObject[] floors;

    // Spawns an enemy on the selected ground tiles and puts them as childs in the Enemies Empty
    private void Start()
    {
            for (int i = 0; i < floors.Length; i++)
            {
                Instantiate(EnemyPrefabs[i * 2 % 3], new Vector3(floors[i].transform.position.x, floors[i].transform.position.y + 0.3f, floors[i].transform.position.z), Quaternion.identity, floors[i].transform.parent.parent);
            }
    }
}
