using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    PlayerMovement movementScript;

    void Awake()
    {
        movementScript = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        movementScript.Run();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
    }

    private void OnTriggerExit2D(Collider2D other)
    {
    }
}
