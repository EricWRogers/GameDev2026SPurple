using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    InputAction moveAction;
    InputAction jumpAction;
    Vector2 moveValue;
    Vector2 jumpForce;
    bool jumpValue;
    Rigidbody2D rb;
    public float forceMultiplier = 10;
    public float jumpMultiplier = 20;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 0.1f;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveValue = moveAction.ReadValue<Vector2>();
        jumpValue |= jumpAction.WasPressedThisFrame();
    }
    void FixedUpdate()
    {
        rb.AddForce(moveValue * forceMultiplier);
        rb.linearVelocityX = rb.linearVelocityX * 0.85f;
        if (jumpValue && IsGrounded())
        {
            rb.AddForce(new Vector2(0.0f, jumpMultiplier));
            jumpValue = false;
        }
    }
    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
    }
}