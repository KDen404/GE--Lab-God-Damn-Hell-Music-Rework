using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public void changeSceneOnClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
 
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindObjectOfType<PlayerStats>().Reset();
        return;
    }
        
}

