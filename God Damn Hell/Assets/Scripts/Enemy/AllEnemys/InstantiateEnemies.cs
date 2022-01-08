using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemies : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    public GameObject[] floors;
    public GameObject enemies;

    // Spawns an enemy on the selected ground tiles and puts them as childs in the Enemies Empty
    private void Start()
    {
            for (int i = 0; i < floors.Length; i++)
            {
                Instantiate(EnemyPrefabs[Random.Range(0, EnemyPrefabs.Length)], floors[i].transform);
            }
    }
}
