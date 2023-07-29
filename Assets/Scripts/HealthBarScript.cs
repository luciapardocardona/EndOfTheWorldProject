using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    float fillFration;

    float HealthValue;
    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    private void Awake()
    {
        HealthValue = HealthBarSpeed;
    }

    void UpdateHealthBar()
    {
        if(HealthValue <= 0)
        {
            // DIES
        }


        if (isOnDangerZone)
        {
            HealthValue -= Time.deltaTime;
        }
        else if (isOnSafeZone)
        {
            HealthValue += Time.deltaTime * 2;
        };


    }
}
