using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetweenLevelsScript : MonoBehaviour
{
    AudioSource audio;
    [SerializeField]
    AudioClip sound;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();

    }
}
