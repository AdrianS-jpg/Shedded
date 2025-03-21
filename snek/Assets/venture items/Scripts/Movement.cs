using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

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
            Debug.Log("Works");
            StartCoroutine(DashCoroutine());
        }
    }

    private IEnumerator DashCoroutine()
    {
        canDash = false;
        isDashing = true;
        Debug.Log("Works");

        _trailRenderer.emitting = true;
        float dashDirection = isFacingRight ? 1f : -1f;

        _rb.linearVelocity = new Vector2(dashDirection * dashSpeed, _rb.linearVelocity.y); // Dash Movement

        yield return new WaitForSeconds(dashDuration);

        _rb.linearVelocity = new Vector2(0f, _rb.linearVelocity.y);

        isDashing = false;
        _trailRenderer.emitting = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
        Debug.Log("still Works");
    }
}
