using System.Collections;
using System.Linq;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using Unity.VisualScripting;
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
    public EnemyMovement eM;
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
        Damage();


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
    public void Damage()
    {
        eM.enemyHealth -= 1;
        Debug.Log("Minus 1 enemy hp");
    }
    public void HandleLook(InputAction.CallbackContext context)
    {
        //Debug.Log(Mouse.current.position.ReadValue());
        //Debug.Log(mainCam.WorldToScreenPoint(gameObject.transform.position));
        //Debug.Log((Mathf.Atan2(Mathf.Abs(mainCam.WorldToScreenPoint(gameObject.transform.position).y - Mouse.current.position.ReadValue().y), Mathf.Abs(mainCam.WorldToScreenPoint(gameObject.transform.position).x - Mouse.current.position.ReadValue().x)) * Mathf.Deg2Rad));
        //var rad = ((Mathf.Atan2(mainCam.WorldToScreenPoint(gameObject.transform.position).y - Mouse.current.position.ReadValue().y, (mainCam.WorldToScreenPoint(gameObject.transform.position).x - Mouse.current.position.ReadValue().x)) * Mathf.Deg2Rad));
        //Debug.Log(new Vector2 (attackArea.GetComponent<PolygonCollider2D>().points[2].x * Mathf.Cos(rad) - attackArea.GetComponent<PolygonCollider2D>().points[2].y * Mathf.Sin(rad), attackArea.GetComponent<PolygonCollider2D>().points[2].x * Mathf.Sin(rad) + attackArea.GetComponent<PolygonCollider2D>().points[2].y * Mathf.Cos(rad)));
        //Vector2 point1 = new Vector2(attackArea.GetComponent<PolygonCollider2D>().points[0].x * Mathf.Cos(rad) - attackArea.GetComponent<PolygonCollider2D>().points[0].y * Mathf.Sin(rad), attackArea.GetComponent<PolygonCollider2D>().points[0].x * Mathf.Sin(rad) + attackArea.GetComponent<PolygonCollider2D>().points[0].y * Mathf.Cos(rad));
        //Vector2 point2 = new Vector2(attackArea.GetComponent<PolygonCollider2D>().points[1].x * Mathf.Cos(rad) - attackArea.GetComponent<PolygonCollider2D>().points[1].y * Mathf.Sin(rad), attackArea.GetComponent<PolygonCollider2D>().points[1].x * Mathf.Sin(rad) + attackArea.GetComponent<PolygonCollider2D>().points[1].y * Mathf.Cos(rad));
        //Vector2 point3 = new Vector2(attackArea.GetComponent<PolygonCollider2D>().points[2].x * Mathf.Cos(rad) - attackArea.GetComponent<PolygonCollider2D>().points[2].y * Mathf.Sin(rad), attackArea.GetComponent<PolygonCollider2D>().points[2].x * Mathf.Sin(rad) + attackArea.GetComponent<PolygonCollider2D>().points[2].y * Mathf.Cos(rad));
        //attackArea.GetComponent<PolygonCollider2D>().points = new[] {point1, point2, point3};

        Debug.Log(Mouse.current.position.ReadValue());
        Debug.Log(mainCam.WorldToScreenPoint(gameObject.transform.position));
        var rad = ((Mathf.Atan2(mainCam.WorldToScreenPoint(gameObject.transform.position).y - Mouse.current.position.ReadValue().y, (mainCam.WorldToScreenPoint(gameObject.transform.position).x - Mouse.current.position.ReadValue().x)) * Mathf.Rad2Deg));
        Debug.Log(rad);
        attackArea.transform.rotation = Quaternion.Euler(0,0,rad);
    }
}
