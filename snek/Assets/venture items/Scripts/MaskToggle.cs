using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MaskToggle : MonoBehaviour
{
    [Header("Reference")]
    public EnemyMovement eM;

    [Header("Variables")]
    public float hideDuration = 5f;

    static public bool isHiding;
    static public bool canHide;
    public Animator animator;
    public GameObject mask;
    public Sprite vers;
    public Sprite redvers;

    void Awake()
    {
        isHiding = false;
        canHide = true;
        hideDuration = 4f;
     
    }
    void Start()
    {
        

        float clamped = Mathf.Clamp(hideDuration, 0, 5); //might be unneeded bc i set the float to specific variables but its here
         
    }

    
    void Update()
    {
        if (eM.enemyKilled == true)
        {
            hideDuration = 5f;
            canHide = true;
        }
        if (canHide == true) {
            mask.GetComponent<SpriteRenderer>().sprite = vers;
        } else {
            mask.GetComponent<SpriteRenderer>().sprite = redvers;
        }

       // The update will always check to see if an enemy has been killed to reset the timer
    }

    public void HandleMask(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(Mask());
            Debug.Log("Pressed E");
            
        }
    }

   private IEnumerator Mask()
    {
        int LayerIgnoreRaycast = LayerMask.NameToLayer("Player");
        int LayerRaycast = LayerMask.NameToLayer("target");;

       
            eM.seePlayer = false;
            isHiding = true;
            canHide = false;
            gameObject.layer = 3;
            animator.SetBool("hide", isHiding);
            
        

        yield return new WaitForSeconds(hideDuration);

        hideDuration = 0; 
        eM.seePlayer = true; 
        isHiding = false;
        canHide = false;
        gameObject.layer = 8;
        animator.SetBool ("hide", isHiding);
        Debug.Log("Stop hiding");
      
        yield return null;
    }
}
