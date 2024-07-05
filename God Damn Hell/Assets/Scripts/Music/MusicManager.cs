using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private uint playingID;
    private string sceneName;
    private bool updated = false;
    private bool isPlayerLowHP = false;

    void Start()
    {
        sceneName = this.gameObject.scene.name.ToString();
        Debug.Log(sceneName);
        switch (sceneName)
        {
            case "First Level":
                playingID = AkSoundEngine.PostEvent("MusicTransitionToIngame", this.gameObject);
                break;
            case "LiveScene-Title":
                playingID = AkSoundEngine.PostEvent("MusicTransitionToMainMenu", this.gameObject);
                break;
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Unloading the scene: " + sceneName);
    }

    public void PlayerHPState(int PlayerHP)
    {
        if (PlayerHP <= 4 && !isPlayerLowHP)
        {
            playingID = AkSoundEngine.PostEvent("PlayerIsLowHP", this.gameObject);
            isPlayerLowHP = true;
        }

        if (PlayerHP > 4 && isPlayerLowHP)
        {
            playingID = AkSoundEngine.PostEvent("PlayerIsNotLowHP", this.gameObject);
            isPlayerLowHP = false;
        }

        if (PlayerHP <= 0)
        {
            playingID = AkSoundEngine.PostEvent("PlayerIsNotLowHP", this.gameObject);
        }
        
            
    }
}
