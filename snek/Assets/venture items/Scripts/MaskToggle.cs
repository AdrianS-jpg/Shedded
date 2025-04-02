using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MaskToggle : MonoBehaviour
{
    [Header("Reference")]
    public EnemyMovement eM;

    [Header("Variables")]
    public float hideDuration = 5f;

    public bool isHiding;
    public bool canHide;

    void Awake()
    {
        hideDuration = 5f;
    }
    void Start()
    {
        isHiding = false;
        canHide = true;

        float clamped = Mathf.Clamp(hideDuration, 0, 5); //might be unneeded bc i set the float to specific variables but its here
         
    }

    
    void Update()
    {
        if (eM.enemyKilled == true)
        {
            hideDuration = 5f;
            canHide = true;
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
        if (hideDuration <= 5 && hideDuration != 0)
        {
            eM.seePlayer = false;
            isHiding = true;
            canHide = false;
            Debug.Log("Hiding");
        }

        yield return new WaitForSeconds(hideDuration);

        hideDuration = 0; 
        eM.seePlayer = true;
        isHiding = false;
        canHide = false;
        Debug.Log("Stop hiding");

        yield return null;
    }
}
