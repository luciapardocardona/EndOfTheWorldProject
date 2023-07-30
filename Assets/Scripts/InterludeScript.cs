using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterludeScript : MonoBehaviour
{
    GameManager gameManager;
    private void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        Invoke(nameof(HandleNextScene), 1f);
    }

    void HandleNextScene()
    {
        gameManager.HandleSceneTransition();
    }
}
