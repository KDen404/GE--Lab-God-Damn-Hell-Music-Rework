using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour
{
    public GameObject enemyInformation;
    public Text victoryMessage;
    public Button exitButton;
    public GameObject victorypanel;
    public GameObject player;

    private Color imageColor;
    private Color messageColor;
    private float timediff = 0f;


    private void Start()
    {
        imageColor = victorypanel.gameObject.GetComponent<Image>().color;
        imageColor.a = 0f;
        victorypanel.gameObject.GetComponent<Image>().color = imageColor;

        messageColor = victoryMessage.color;
        messageColor.a = -0.3f;
        victoryMessage.color = messageColor;

        exitButton.gameObject.SetActive(false);

        victorypanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        // the Codes function is to activate the victory screen, once all enemies are dead
        // If the Exit Button gets activated we do not need all this code to run in the background anymore
        if (exitButton.gameObject.activeSelf == false)
        {
            if ( enemyInformation.GetComponent<TotalEnemyCount>().totalEnemiesAlive == 0)                                  
            {
                if (this.transform.GetChild(1).gameObject.activeSelf)
                {
                    //stoppt die musik beim auftreten des Victory Screens
                    enemyInformation.GetComponent<PlayMusicOnStart>().stop_music();
                    // Deaktiviert alle Gegner wenn Victory screen aktiviert (stopt ebenfalls den sound bug)
                    for (int i = 0; i < enemyInformation.GetComponent<InstantiateEnemies>().instantiatedEnemies.Count; i++)
                    {
                        enemyInformation.GetComponent<InstantiateEnemies>().instantiatedEnemies[i].SetActive(false);
                    }
                }

                Debug.Log(messageColor.a);
                victorypanel.gameObject.SetActive(true);

                timediff = Time.deltaTime / 3f;

                messageColor.a += timediff;
                victoryMessage.color = messageColor;

                if (messageColor.a >= 1f)
                {
                    exitButton.gameObject.SetActive(true);

                    messageColor.a = 1f;
                    victoryMessage.color = messageColor;
                }
            }
        }
    }
}
