using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Scene currentScene;
    private string nextScene;

    public void HandleSceneTransition()
    {
        this.currentScene = SceneManager.GetActiveScene();
        this.nextScene = currentScene.name switch
        {
            SceneConstants.Level1 => SceneConstants.Level2,
            _ => SceneConstants.Level1
        };

        this.GoToNextScene();
    }

    private void GoToNextScene()
    {
        SceneManager.LoadScene(this.nextScene);
    }
}
    
