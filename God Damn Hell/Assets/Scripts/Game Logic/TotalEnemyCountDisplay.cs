using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalEnemyCountDisplay : MonoBehaviour
{
    public TotalEnemyCount enemyCount;
    public Image[] numbers;
    public int amountEnemies;

    // Only works in Update()
    // Counts the enemies in the entire level and enables / disables sprites that reflect the remaining enemies alive
    // Better solution would have been to collect all the enemies once and update the sprites when an enemy object gets destroyed
    private void Update()
    {
        amountEnemies = enemyCount.totalEnemiesAlive;

        for (int i = 0; i <= 2; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                int rightDigit = amountEnemies % 10;
                if (j == rightDigit)
                {
                    numbers[j].enabled = true;
                    continue;
                }
                else
                {
                    numbers[j].enabled = false;
                }
            }

            int leftDigit = amountEnemies / 10;
            if (i == leftDigit)
            {
                numbers[i + 10].enabled = true;
                continue;
            }
            else
            {
                numbers[i + 10].enabled = false;
            }
        }
    }
}
