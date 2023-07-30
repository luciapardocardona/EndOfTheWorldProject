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
            SceneConstants.Menu => SceneConstants.Controles,
            SceneConstants.Controles => SceneConstants.Start,
            SceneConstants.Start => SceneConstants.Level1,
            SceneConstants.Level1 => SceneConstants.Level1Level2,
            SceneConstants.Level1Level2 => SceneConstants.Level2,
            SceneConstants.Level2 => SceneConstants.Level2Level3,
            SceneConstants.Level2Level3 => SceneConstants.Level3,
            SceneConstants.Level3 => SceneConstants.End,
            SceneConstants.End => SceneConstants.Credits,
            _ => SceneConstants.Menu
        };

        this.GoToNextScene();
    }

    private void GoToNextScene()
    {
        SceneManager.LoadScene(this.nextScene);
    }
}

