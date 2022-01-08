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

    private Color imageColor;
    private Color messageColor;


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

                imageColor.a += 0.002f;
                deathpanel.gameObject.GetComponent<Image>().color = imageColor;
            
                messageColor.a += 0.002f;
                deathMessage.color = messageColor;

                if(imageColor.a >= 1f)
                {
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
