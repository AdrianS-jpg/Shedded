using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;

    private bool attacking = false;

    private float timmeToAttack = 0.25f;
    private float timer = 0f;
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }


    void Update()
    {
        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer > timmeToAttack)
            {
                timer = 0f;
                attacking = false;  
                attackArea.SetActive(attacking);
     
            }


        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        Attack();

    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(!attacking);  
    }
}
