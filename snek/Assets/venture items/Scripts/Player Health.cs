using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] 
    public int maxHealth = 100;
    public int health;
    public Slider slider;

    void Start()
    {
       health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;
    }

    public void Damage(int amount)
    {
        health -= amount; 
        slider.value = health;

        if (health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("You Died!");
        Destroy(gameObject);
    }
}

