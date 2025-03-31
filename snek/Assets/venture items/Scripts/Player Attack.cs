using System.Collections;
using System.Linq;
using Unity.Mathematics.Geometry;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;

    private bool attacking = false;
    public Camera mainCam;
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    private bool canAttack = true; 
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        attackArea.SetActive(true);
    }

    private void Update()
    {
    }

    IEnumerator AttackBetter()
    {
        attacking = true;
        canAttack = false;
        attackArea.SetActive(true);

        yield return new WaitForSeconds(timeToAttack);

        attacking = false;
        attackArea.SetActive(false);

        yield return new WaitForSeconds(timer);
        
        canAttack = true;
    }

    public void HandleAttack(InputAction.CallbackContext context)
    {

        if (context.performed && canAttack)
        {
            StartCoroutine(AttackBetter());
        }
    }

    public void HandleLook(InputAction.CallbackContext context)
    {
        Debug.Log(Mouse.current.position.ReadValue());
        Debug.Log(mainCam.WorldToScreenPoint(gameObject.transform.position));
        Debug.Log((Mathf.Atan2(mainCam.WorldToScreenPoint(gameObject.transform.position).x - Mouse.current.position.ReadValue().x, mainCam.WorldToScreenPoint(gameObject.transform.position).y - Mouse.current.position.ReadValue().y)) * (180/Mathf.PI));
        var rad = (Mathf.Atan2(mainCam.WorldToScreenPoint(gameObject.transform.position).x - Mouse.current.position.ReadValue().x, mainCam.WorldToScreenPoint(gameObject.transform.position).y - Mouse.current.position.ReadValue().y));
        Debug.Log(new Vector2 (attackArea.GetComponent<PolygonCollider2D>().points[2].x * Mathf.Cos(rad) - attackArea.GetComponent<PolygonCollider2D>().points[2].y * Mathf.Sin(rad), attackArea.GetComponent<PolygonCollider2D>().points[2].x * Mathf.Sin(rad) + attackArea.GetComponent<PolygonCollider2D>().points[2].y * Mathf.Cos(rad)));
        attackArea.GetComponent<PolygonCollider2D>().points[0] = new Vector2(attackArea.GetComponent<PolygonCollider2D>().points[0].x * Mathf.Cos(rad) - attackArea.GetComponent<PolygonCollider2D>().points[0].y * Mathf.Sin(rad), attackArea.GetComponent<PolygonCollider2D>().points[0].x * Mathf.Sin(rad) + attackArea.GetComponent<PolygonCollider2D>().points[0].y * Mathf.Cos(rad));
        attackArea.GetComponent<PolygonCollider2D>().points[1] = new Vector2(attackArea.GetComponent<PolygonCollider2D>().points[1].x * Mathf.Cos(rad) - attackArea.GetComponent<PolygonCollider2D>().points[1].y * Mathf.Sin(rad), attackArea.GetComponent<PolygonCollider2D>().points[1].x * Mathf.Sin(rad) + attackArea.GetComponent<PolygonCollider2D>().points[1].y * Mathf.Cos(rad));
        attackArea.GetComponent<PolygonCollider2D>().points[2] = new Vector2(attackArea.GetComponent<PolygonCollider2D>().points[2].x * Mathf.Cos(rad) - attackArea.GetComponent<PolygonCollider2D>().points[2].y * Mathf.Sin(rad), attackArea.GetComponent<PolygonCollider2D>().points[2].x * Mathf.Sin(rad) + attackArea.GetComponent<PolygonCollider2D>().points[2].y * Mathf.Cos(rad));
    }
}
