using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackArea : MonoBehaviour
{
    private int damage = 3;

    private void OnTriggerEnter2D(Collider2D collider)
    {
       if (collider.GetComponent<PlayerHealth>() != null)
        {
            PlayerHealth health = collider.GetComponent<PlayerHealth>();

            health.Damage(damage);
        }    
    }
}
