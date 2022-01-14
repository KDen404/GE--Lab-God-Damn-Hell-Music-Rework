using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // If the colliding object is a player (checked via layer!), add 3 HP but clamp the current HP to the players max HP to avoid overflow
        PlayerStats playerstats = other.GetComponent<PlayerStats>();
        playerstats.currentHealthPoints = (int)Mathf.Clamp(playerstats.currentHealthPoints + 3, 0f, playerstats.maxHealthPoints);
        AkSoundEngine.PostEvent("PotionSlurp", gameObject);
        Destroy(gameObject);
    }
}
