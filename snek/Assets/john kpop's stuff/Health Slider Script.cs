using UnityEngine;
using UnityEngine.UI;

public class HealthSliderScript : MonoBehaviour
{
    public int health;
    public int maxHealth = 100;
    public Slider slider;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void TakeDamage(int amount)
    {
        health -= amount;
        slider.value = health;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
