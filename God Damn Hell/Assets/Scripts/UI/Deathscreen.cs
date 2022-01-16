using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deathscreen : MonoBehaviour
{
    public GameObject player;
    public Text deathMessage;
    public Button exitButton;
    public GameObject deathpanel;
    public GameObject level_empty;


    private Color imageColor;
    private Color messageColor;
    private float timediff = 0f;


    private void Start()
    {
        imageColor = deathpanel.gameObject.GetComponent<Image>().color;
        imageColor.a = 0f;
        deathpanel.gameObject.GetComponent<Image>().color = imageColor;

        messageColor = deathMessage.color;
        messageColor.a = 0f;
        deathMessage.color = messageColor;

        exitButton.gameObject.SetActive(false);

        deathpanel.gameObject.SetActive(false);
    }

    private void Update()
    {
        // the Codes function is to fade to black once the Player dies.
        // If the Exit Button gets activated we do not need all this code to run in the background anymore
        if(exitButton.gameObject.activeSelf == false)
        {   
            if(player.GetComponent<PlayerStats>().currentHealthPoints <= 0) {
                
                deathpanel.gameObject.SetActive(true);

                timediff = Time.deltaTime / 3f;

                imageColor.a += timediff;
                deathpanel.gameObject.GetComponent<Image>().color = imageColor;
            
                messageColor.a += timediff;
                deathMessage.color = messageColor;

                

                if (imageColor.a >= 1.0f)
                {
                    if (this.transform.GetChild(0).gameObject.activeSelf)
                    {
                        //stoppt die musik beim auftreten des Victory Screens
                        level_empty.GetComponent<PlayMusicOnStart>().stop_music();
                        //Deaktiviert alle Gegner wenn Victory screen aktiviert (stopt ebenfalls den sound bug)
                        for (int i = 0; i < level_empty.GetComponent<TotalEnemyCount>().totalEnemyCount.Count; i++)
                        {
                            level_empty.GetComponent<TotalEnemyCount>().totalEnemyCount[i].gameObject.SetActive(false);
                        }

                    }

                    exitButton.gameObject.SetActive(true);

                    imageColor.a = 1f;      //alpha value gets set back to 1 (not really needed but I prefer it this way)
                    deathpanel.gameObject.GetComponent<Image>().color = imageColor;

                    messageColor.a = 1f;
                    deathMessage.color = messageColor;
                }
            }
        }
        
    }
}
