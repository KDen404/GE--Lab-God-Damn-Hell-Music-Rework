using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int maxHealthPoints = 20;
    public int currentHealthPoints = 20;
    public bool alive = true;
    [CanBeNull] public GameObject WWiseGlobal;
    private uint playingID;
    
    public void Reset()
    {
        currentHealthPoints = 20;
        alive = true;
    }

    public void Hit(int damage)
    {
        if (currentHealthPoints <= 0)
            return;
        currentHealthPoints -= damage;
        
        if (WWiseGlobal != null)
            WWiseGlobal.GetComponent<MusicManager>().PlayerHPState(currentHealthPoints);
        
        if (currentHealthPoints <= 0)
        {
            alive = false;
        }
    }
}
