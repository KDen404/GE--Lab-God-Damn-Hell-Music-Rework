using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalEnemyCountDisplay : MonoBehaviour
{
    public TotalEnemyCount enemyCount;
    public Image[] numbers;
    public string numbersString;
    private string number;

    private void Update()
    {
        numbersString = enemyCount.totalEnemiesAlive.ToString();
        
        if (numbersString.Length > 1)
        {
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    number = j.ToString();
                    if (number[0] == numbersString[1])
                    {
                        numbers[j].enabled = true;
                        continue;
                    }
                    else
                    {
                        numbers[j].enabled = false;
                    }
                }

                number = i.ToString();
                if (number[0] == numbersString[0])
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
        else
        {
            for (int i = 0; i <= 2; i++)
            {
                numbers[i + 10].enabled = false;
            }

            for (int j = 0; j < 10; j++)
            {
                number = j.ToString();
                if (number[0] == numbersString[0])
                {
                    numbers[j].enabled = true;
                    continue;
                }
                else
                {
                    numbers[j].enabled = false;
                }
            }
        }
    }
}
