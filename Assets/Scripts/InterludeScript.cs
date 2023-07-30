using UnityEngine;
using UnityEngine.Video;

public class InterludeScript : MonoBehaviour
{
    GameManager gameManager;
    [SerializeField]
    VideoClip video;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        Invoke(nameof(HandleNextScene), (float)video.length + 0.5f);
    }

    void HandleNextScene()
    {
        gameManager.HandleSceneTransition();
    }
}
