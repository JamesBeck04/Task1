using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] float maxHitPoints = 100f;
    float hitPoints;

    public Slider healthSlider;

    [SerializeField] GameObject HealthBar;
    [SerializeField] GameObject GameOverpanel;

    void Start()
    {
        hitPoints = maxHitPoints;
    }

    void Hit(float rawDamage)
    {
        hitPoints -= rawDamage;
        SetHealthSlider();

        Debug.Log("OUCH: " + hitPoints.ToString());

        if (hitPoints <= 0)
        {
            HealthBar.SetActive(false);
            GameOverpanel.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0f;
            Debug.Log("TODO: GAME OVER - YOU DIED");
        }
    }

    void SetHealthSlider()
    {
        if (healthSlider != null)
        {
            healthSlider.value = NormalisedHitPoints();
        }
    }

    float NormalisedHitPoints()
    {
        return hitPoints / maxHitPoints;
    }
}