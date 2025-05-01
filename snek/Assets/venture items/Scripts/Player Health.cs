using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] 
    static public int maxHealth = 5;
    static public int health;
    static public bool isHit = false;
    public Animator animator;
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
        //this was being annoying when testing, removed for now
        //he annoying af bro idk why he calls when i RESET THE SCENE BUT OK I GUESS DO YOUR OWN THING   
        //Destroy(gameObject);
    }
    //this is optimal i promise
    IEnumerator Damagei()
    {
        animator.SetBool("attacking", false);
        GetComponent<SpriteRenderer>().color = Color.red;
        GetComponent<Movement>().canDash = false;
        isHit = true;
        gameObject.GetComponent<Movement>().enabled = true;
        yield return new WaitForSeconds(1.5f);
        GetComponent<SpriteRenderer>().color = Color.white;
        isHit = false;
        GetComponent<Movement>().movementSpeed = 5;
        GetComponent<Movement>().canDash = true;
        yield break;
    }
}

