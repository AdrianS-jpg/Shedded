using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    void Update()
    {
        if (health > 0)
        {
           // Die();
        }
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }

        this.health += amount;
    }

    //private void Die()
    //{
    //    Debug.Log("You Died!");
    //    Destroy(gameObject);
    //}
}

