using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] 
    public int maxHealth = 5;
    public int health;
   // public Slider slider;
    public EnemyMovement eM;

    void Start()
    {
        health = maxHealth;
       // slider.maxValue = maxHealth;
       // slider.value = health;
    }

    void Update()
    {
        //slider.value = health;

        if (health <= 0)
        {
            Die();
        }

    }
    public void Damage()
    {
        eM.enemyHealth -= 1;
        Debug.Log("Minus 1 enemy hp");
    }

    private void Die()
    {
        Debug.Log("You Died!");
        Destroy(gameObject);
    }
}

