using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections; // Needed for Cororoutines DONT TOUCH!!!!!

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Rigidbody2D rb;
    private float moveInput;

    [Header("Dash Settings")]
    [SerializeField] private float dashingPower = 24f;
    [SerializeField] private float dashingTime = 0.2f;
    [SerializeField] private float dashingCooldown = 1f;

    private bool canDash = true;
    private bool isDashing;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDashing) return;

        moveInput = 0;

        if (Keyboard.current.aKey.isPressed)
            moveInput = -1;

        if (Keyboard.current.dKey.isPressed)
            moveInput = 1;

        if (Keyboard.current.qKey.wasPressedThisFrame && canDash)
        {
            StartCoroutine(Dash());
        }
            
    }

    void FixedUpdate()
    {
        if (isDashing) return;

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        // Store original gravity to restore it after the dash
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        // Apply dash velocity based on last move direction
        float dashDirection = moveInput != 0 ? moveInput : (transform.localScale.x > 0 ? 1 : -1);
        rb.linearVelocity = new Vector2(dashDirection * dashingPower, 0f);

        yield return new WaitForSeconds(dashingTime);

        // Reset state after dash duration
        rb.gravityScale = originalGravity;
        isDashing = false;

        // Wait for cooldown
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }
}