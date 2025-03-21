using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Movement : MonoBehaviour
{
    [Header("General")]
    bool isFacingRight = true; 

    [Header("Movement")]
    public float movementSpeed;
    private Rigidbody2D _rb;
    private Vector2 _moveAmount;

    [Header("Dash/Sprint")]
    public float dashSpeed = 20f;
    public float dashDuration = 0.1f;
    public float dashCooldown = 0.1f;
    bool isDashing;
    bool canDash = true;
    TrailRenderer _trailRenderer;
  
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.linearVelocityX = _moveAmount.x * movementSpeed;
        _rb.linearVelocityY = _moveAmount.y * movementSpeed;
    


        // put ani code above the if isDashing for it to run properly
         
        if (isDashing)
        {
            return;
        }
    }

    public void HandleMovement(InputAction.CallbackContext context)
    {
        _moveAmount = context.ReadValue<Vector2>(); 
    }

    public void HandleDash(InputAction.CallbackContext context)
    {
        if (context.performed && canDash)
        {
           
            StartCoroutine(DashCoroutine());
        }
    }

    private IEnumerator DashCoroutine()
    {
        canDash = false;
        isDashing = true;
        

        // _trailRenderer.emitting = true;
        float dashDirection = isFacingRight ? 1f : -1f;

        Vector2 dash = _rb.position;

        dash += new Vector2((dashSpeed * 0.1f), _rb.linearVelocity.y);

        _rb.MovePosition(dash);  // Dash Movement
        Debug.Log("Works");

        //for (int i = 0; i < 100; i++)
        //{
        //    Vector2 pos = _rb.position;

        //    pos += new Vector2(0.1f, 0.0f);

        //    _rb.MovePosition(pos);

        //    yield return null;

        //}

        yield return new WaitForSeconds(dashDuration);

        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, _rb.linearVelocity.y);

        isDashing = false;
       // _trailRenderer.emitting = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
        
    }
}
