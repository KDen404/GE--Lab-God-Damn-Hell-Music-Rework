using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int maxHealthPoints = 20;
    public int currentHealthPoints = 20;
    public bool alive = true;
    [CanBeNull] public GameObject WWiseGlobal;
    private uint playingID;

    public void Hit(int damage)
    {
        currentHealthPoints -= damage;
        
        if (WWiseGlobal != null)
            WWiseGlobal.GetComponent<MusicManager>().PlayerHPState(currentHealthPoints);
        
        if (currentHealthPoints <= 0)
        {
            alive = false;
        }
    }
}
