using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;
    private bool canAttack = true; 
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }


    void Update()
    {
        if (attacking)
        {
            timer += Time.deltaTime;

            if (timer > timeToAttack)
            {
                timer = 0f;
                canAttack = true;
                attacking = false;
                attackArea.SetActive(false);
            }
        }
    }

    private void Attack()
    {
        attacking = true; canAttack = false; 
        attackArea.SetActive(true );  

    }

    public void HandleAttack(InputAction.CallbackContext context)
    {

        if (context.performed && canAttack)
        {
            Attack();
        }
    }
}
