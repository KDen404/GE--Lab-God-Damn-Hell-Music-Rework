using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPotions : MonoBehaviour
{
    private int consumablePotions;
    public Cardsystem cardsystemPotionInformation;
    public GameObject player;
    private PlayerStats playerStats;

    private void Start()
    {
        consumablePotions = cardsystemPotionInformation.getPotionNumber();
        playerStats = player.GetComponent<PlayerStats>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (consumablePotions>0)
            {
                consumablePotions -= 1;
                ConsumePotion();
            }
        }
    }

    private void ConsumePotion()
    {
        playerStats.currentHealthPoints = (int)Mathf.Clamp(playerStats.currentHealthPoints + 6, 0f, playerStats.maxHealthPoints);
        Debug.Log("consumed");
    }
}
