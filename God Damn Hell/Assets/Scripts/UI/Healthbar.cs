using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    private Image healthbar;
    private float currentHealth;
    private float maxHealth;
    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = FindObjectOfType<PlayerStats>();
        healthbar = GetComponent<Image>();
        maxHealth = playerStats.maxHealthPoints;
    }

    private void Update()
    {
        currentHealth = playerStats.currentHealthPoints;
        healthbar.fillAmount = currentHealth / maxHealth;
    }
}
