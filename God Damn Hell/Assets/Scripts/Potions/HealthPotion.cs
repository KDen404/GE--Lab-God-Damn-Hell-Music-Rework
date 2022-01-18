using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    // Stefans Version, Instant consumption on walk over

    //private void OnTriggerEnter(Collider other)
    //{
    //    // If the colliding object is a player (checked via layer!), add 3 HP but clamp the current HP to the players max HP to avoid overflow
    //    PlayerStats playerstats = other.GetComponent<PlayerStats>();
    //    playerstats.currentHealthPoints = (int)Mathf.Clamp(playerstats.currentHealthPoints + 6, 0f, playerstats.maxHealthPoints);
    //    AkSoundEngine.PostEvent("PotionSlurp", gameObject);
    //    Destroy(gameObject);
    //}


    // Martins Version, collect Potions, instead of instant cosumption
    public GameObject currentPotionNumber;
    private void Start()
    {
        //currentPotionNumber = GameObject.Find("Card and PotionSystem");
    }
    private void OnTriggerEnter(Collider other)
    {
        currentPotionNumber.GetComponent<PlayerPotions>().consumablePotions += 1;
        currentPotionNumber.GetComponent<PlayerPotions>().UpdatePotionSprite();
        Destroy(gameObject);
    }
}
