using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    public GameObject pauseMenuBackground;

    public GameObject deathScreen;
    public GameObject victoryScreen;

    private void Start()
    {
        pauseMenuBackground.SetActive(false);
    }
    private void Update()
    {
        if(deathScreen.activeSelf || victoryScreen.activeSelf)      // if you win or die, the pausemenu can no longer be opend, and is forfully closed if open
        {
            if (pauseMenuBackground.activeSelf)             //closes the pauseMenu
            {
                togglePauseScreen();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                togglePauseScreen();
            }
        }

    }

    public void togglePauseScreen()
    {
        pauseMenuBackground.SetActive(!pauseMenuBackground.activeSelf);
        if (pauseMenuBackground.activeSelf)     // un- /pauses the game based on pauseMenuBackground.activeSelf, if (Time.timeScale == 1.0) can cause errors based on float comparisons
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
}
