using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPotions : MonoBehaviour
{
    public int consumablePotions;
    public Cardsystem cardsystemPotionInformation;
    public GameObject player;
    private PlayerStats playerStats;

    public Image potionNumberDisplay;
    public Sprite[] potionSpritesList;          // list  of the Number Sprites

    private void Start()
    {
        consumablePotions = cardsystemPotionInformation.getPotionNumber();
        playerStats = player.GetComponent<PlayerStats>();
        potionNumberDisplay.sprite = potionSpritesList[consumablePotions];
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
        UpdatePotionSprite();
    }

    public void UpdatePotionSprite()
    {
        potionNumberDisplay.sprite = potionSpritesList[consumablePotions];
    }
}
