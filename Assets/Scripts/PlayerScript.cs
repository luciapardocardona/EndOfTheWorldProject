using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    PlayerMovement movementScript;
    [SerializeField] HealthBarScript healthBarScript;
    GameManager gameManager;

    void Awake()
    {
        movementScript = GetComponent<PlayerMovement>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    void Update()
    {
        movementScript.Run();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case CollisionConstants.LevelEnd: gameManager.HandleSceneTransition(); break;
            case CollisionConstants.InstantKill: healthBarScript.InstantKill(); break;
            case CollisionConstants.SlowKill: healthBarScript.ToggleDanger(true); break;
            default: break;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        healthBarScript.ToggleDanger(false);
    }
}
