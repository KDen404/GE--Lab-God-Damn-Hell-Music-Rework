using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public void changeSceneOnClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
        
}

