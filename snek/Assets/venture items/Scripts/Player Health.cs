using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] 
    static public int maxHealth = 5;
    static public int health;
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
        health -= 1;
        StartCoroutine(Damagei());
        Debug.Log("AHHHHHHHHHHHHHHHHHHHHHHHHHH");
    }

    private void Die()
    {
        Debug.Log("You Died!");
        Destroy(gameObject);
    }
    //this is optimal i promise
    IEnumerator Damagei()
    {
        //GetComponent<SpriteRenderer>().color = Color.magenta;
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Movement>().movementSpeed = 0;
        GetComponent<Movement>().canDash = false;
        yield return new WaitForSeconds(1.5f);
       // GetComponent<SpriteRenderer>().color = Color.white;
        GetComponent<CapsuleCollider2D>().enabled = true;
        GetComponent<Movement>().movementSpeed = 5;
        GetComponent<Movement>().canDash = true;
        yield break;
    }
}

