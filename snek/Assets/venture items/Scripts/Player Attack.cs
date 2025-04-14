using System.Collections;
using System.Linq;
using System.Runtime.InteropServices;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerAttack : MonoBehaviour
{
    [Header("Bools")]
    private bool attacking = false;
    private bool canAttack = true;

    [Header("Numbers")]
    private float timeToAttack = 0.25f;
    private float timer = 0f;

    [Header("Components")]
    private GameObject attackArea = default;
    public Camera mainCam;
    public EnemyMovement eM;
    public PolygonCollider2D hit;

   
   
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
        if (rad < 0)
        {
            rad = 180 + rad;
        } else
        {
            rad = rad - 180;
        }
            attackArea.transform.rotation = Quaternion.Euler(1, 1, rad);

        //third times the charm??

        //float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        //float moveVertical = Input.GetAxisRaw ("Vertical");

        //Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //attackArea.transform.rotation = Quaternion.Euler(movement);

        //attackArea.transform.Translate(movement, Space.World);
    }
}
