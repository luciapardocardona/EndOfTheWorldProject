using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenLevelsScript : MonoBehaviour
{
    AudioSource audio;
    [SerializeField]
    AudioClip sound;

    GameManager gameManager;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        audio.PlayOneShot(sound);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Invoke(nameof(NextLevel), sound.length);
    }

    void NextLevel()
    {
        gameManager.HandleSceneTransition();
    }
}
