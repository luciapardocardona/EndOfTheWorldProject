using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField]
    float HealthBarSpeed = 30f;

    [SerializeField]
    float HealthBarRecovery = 10f;

    [SerializeField]
    bool isOnDangerZone = false;
    
    [SerializeField]
    bool isOnSafeZone = false;

    [SerializeField]
    float fillFraction = 1f;

    [SerializeField]
    Image HealthBarImage;

    float HealthValue;
    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    private void Awake()
    {
        HealthValue = HealthBarSpeed;
        fillFraction = 1f;
    }

    void UpdateHealthBar()
    {
        if(fillFraction <= 0)
        {
            Debug.Log("HA MUERTO HOSTIAS");
        }
        else if (isOnDangerZone && fillFraction > 0) // SET 0 ON FINAL GAME
        {
            HealthValue -= Time.deltaTime;

        }
        else if (isOnSafeZone && fillFraction < 1)
        {
            HealthValue += Time.deltaTime * 2;
        };

        fillFraction = Mathf.Clamp01(HealthValue / HealthBarSpeed);

        HealthBarImage.fillAmount = fillFraction;
    }
}
