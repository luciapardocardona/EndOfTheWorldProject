using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        HealthBarImage.fillAmount = fillFraction;
    }

    void UpdateHealthBar()
    {
        if(fillFraction <= 0)
        {
            this.Kill();
        }
        else if (isOnDangerZone && fillFraction > 0)
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

    void InstantKill()
    {
        while (fillFraction > 0)
        {
            HealthValue += Time.deltaTime * 7;
            fillFraction = Mathf.Clamp01(HealthValue / HealthBarSpeed);
            HealthBarImage.fillAmount = fillFraction;
        }

        this.Kill();
    }

    void Kill()
    {
        isOnDangerZone = false;
        isOnSafeZone = true;
        Invoke(nameof(ReloadLevel), 2f);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
