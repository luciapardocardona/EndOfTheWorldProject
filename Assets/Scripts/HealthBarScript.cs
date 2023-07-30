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
    public bool isOnDangerZone = false;

    [SerializeField]
    public bool isOnSafeZone = false;

    [SerializeField]
    float fillFraction = 1f;

    [SerializeField]
    Image HealthBarImage;

    [SerializeField]
    Image HealthWarningImage;

    float HealthValue;
    // Update is called once per frame
    [SerializeField]
    AudioClip[] deathSounds;

    bool hasAlreadyDead;

    bool alfaDecerasing = false;

    float alfaWarning = 0f;

    [SerializeField] PlayerMovement playerMovement;
    AudioSource sound;

    Color colorMuerte;
    void Update()
    {
        UpdateHealthBar();
    }

    private void Awake()
    {
        colorMuerte = HealthWarningImage.color;

        hasAlreadyDead = false;
        HealthValue = HealthBarSpeed;
        fillFraction = 1f;
        HealthBarImage.fillAmount = fillFraction;
        sound = GetComponent<AudioSource>();
    }

    public void ToggleDanger(bool danger)
    {
        Debug.Log(danger);
        isOnDangerZone = danger;
        isOnSafeZone = !danger;
    }

    void UpdateHealthBar()
    {
        if (fillFraction <= 0)
        {
            playerMovement.Dead();

            if (!hasAlreadyDead)
            {
                sound.PlayOneShot(deathSounds[Random.Range(0, deathSounds.Length)]);
            }

            this.Kill();
        }
        else if (isOnDangerZone && fillFraction > 0)
        {
            DeadWarning();
            HealthValue -= Time.deltaTime;
        }
        else if (isOnSafeZone && fillFraction < 1)
        {
            HealthValue += Time.deltaTime * 2;

            HealthWarningImage.color = new Color(colorMuerte.r, colorMuerte.g, colorMuerte.b, 0);
        };

        fillFraction = Mathf.Clamp01(HealthValue / HealthBarSpeed);

        HealthBarImage.fillAmount = fillFraction;
    }

    public void InstantKill()
    {
        while (fillFraction > 0)
        {
            HealthValue -= Time.deltaTime * 2.5f;
            fillFraction = Mathf.Clamp01(HealthValue / HealthBarSpeed);
            HealthBarImage.fillAmount = fillFraction;
        }

        playerMovement.Dead();

        if (!hasAlreadyDead)
        {
            sound.PlayOneShot(deathSounds[Random.Range(0, deathSounds.Length)]);
        }
        this.Kill();
    }

    void Kill()
    {
        hasAlreadyDead = true;
        isOnDangerZone = false;
        isOnSafeZone = true;
        Invoke(nameof(ReloadLevel), 2f);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DeadWarning()
    {
        HealthWarningImage.color = new Color(colorMuerte.r, colorMuerte.g, colorMuerte.b, alfaWarning);

        if (alfaWarning < 0.3f && !alfaDecerasing)
        {
            alfaWarning += 0.01f;
        }
        else if (alfaWarning <= 0)
        {
            alfaDecerasing = false;
        }
        else
        {
            alfaWarning -= 0.01f;
            alfaDecerasing = true;
        }
    }
}
