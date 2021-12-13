using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateEnemies : MonoBehaviour
{
    public GameObject DemonFighterPreFab;
    public GameObject[] Floors;
    public int amountOfEnemies = 1;
    private bool hasBeenTriggered = false;


    // Spawns an enemy on every "tile" of ground -> tiles need to be put in the array
    private void OnTriggerEnter(Collider other)
    {
        if (hasBeenTriggered == false)
        {
            for (int i = 0; i < Floors.Length; i++)
            {
                Instantiate(DemonFighterPreFab, Floors[i].transform);
            }

            Debug.Log("Enemies should spawn now!");
        }
        hasBeenTriggered = true;
    }
}
