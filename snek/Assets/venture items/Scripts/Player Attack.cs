using System.Collections;
using System.Collections.Generic;
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
    public bool attacking = false;
    public bool canAttack = true;

    [Header("Numbers")]
    private float timeToAttack = 0.5f;
    private float timer = 0f;

    [Header("Components")]
    static public GameObject attackArea = default;
    public Camera mainCam;
    public EnemyMovement eM;
    public PolygonCollider2D hit;
    public Animator animator; 
    
    [Header("Adrians bull")]
    static public List<GameObject> touching = new List<GameObject>();
    public LayerMask layers;
    public Movement move;

   
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        attackArea.SetActive(false);
        move = GetComponent<Movement>();
    }

    private void Update()
    {
        Debug.Log(touching.Count);
       
    }

    IEnumerator AttackBetter()
    {
        if (GetComponent<SpriteRenderer>().flipX == false)
        {
            hit.transform.rotation = Quaternion.Euler(0, 0, 0);
        } else
        {
            hit.transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        gameObject.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(0, 0);
        gameObject.GetComponent<Movement>().enabled = false;
        attacking = true;
        animator.SetBool("attacking", attacking);
        canAttack = false;
        attackArea.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        List<GameObject> FINE = touching;
        for (int i = 0; i < 20; i++)
        {
            if (FINE.Count > 0)
            {
                for (int j = 0; j < FINE.Count; j++)
                {
                        FINE[j].GetComponent<EnemyMovement>().damage();
                    
                }
            }
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(0.1f);
        attacking = false;
        animator.SetBool("attacking", false);
        attackArea.SetActive(false);
        gameObject.GetComponent<Movement>().enabled = true;
        if (Input.GetKeyDown(KeyCode.A))
        {
            move.ayy = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            move.dee = true;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            move.ayy = false;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            move.dee = false;
        }
        if (move.ayy == true && move.dee == false)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (move.ayy == false && move.dee == true)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
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

        //Debug.Log(Mouse.current.position.ReadValue());
        //Debug.Log(mainCam.WorldToScreenPoint(gameObject.transform.position));
        //var rad = ((Mathf.Atan2(mainCam.WorldToScreenPoint(gameObject.transform.position).y - Mouse.current.position.ReadValue().y, (mainCam.WorldToScreenPoint(gameObject.transform.position).x - Mouse.current.position.ReadValue().x)) * Mathf.Rad2Deg));
        //if (rad < 0)
        //{
        //    rad = 180 + rad;
        //} else
        //{
        //    rad = rad - 180;
        //}
        //    attackArea.transform.rotation = Quaternion.Euler(1, 1, rad);

        //third times the charm??

        //lies
        //misinformation
        //im being gaslight chat

        // wrong grammer. youre being gaslit**


        //float moveHorizontal = Input.GetAxisRaw ("Horizontal");
        //float moveVertical = Input.GetAxisRaw ("Vertical");

        //Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //attackArea.transform.rotation = Quaternion.Euler(movement);

        //attackArea.transform.Translate(movement, Space.World);
    }


}
