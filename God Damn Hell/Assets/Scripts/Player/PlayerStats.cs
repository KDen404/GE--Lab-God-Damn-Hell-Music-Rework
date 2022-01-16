using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealthPoints = 20;
    public int currentHealthPoints = 20;
    public bool alive = true;

    private void Update()
    {
        if (currentHealthPoints <= 0)
            alive = false;
    }
}
