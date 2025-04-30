using UnityEngine;
using UnityEngine.UI;

public class HealthSliderScript : MonoBehaviour
{
    public PlayerHealth PlayerHealth;
    public Slider slider;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayerHealth.health = PlayerHealth.maxHealth;
        slider.maxValue = PlayerHealth.maxHealth;
        slider.value = PlayerHealth.health;
    }

  
}
