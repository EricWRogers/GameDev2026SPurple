using JetBrains.Annotations;
using Unity.Collections;
using Unity.VectorGraphics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public UnityEvent flipFlop;
    InputAction moveAction;
    InputAction jumpAction;
    Vector2 moveValue;
    Vector2 jumpForce;
    bool jumpValue;
    Rigidbody2D rb;
    public float forceMultiplier = 10;
    public float jumpMultiplier = 20;
    public GameObject canvas;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 0.1f;
    void Start()
    {
        GameObject.Find("Canvas").SetActive(false);
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        moveValue.x = moveAction.ReadValue<Vector2>().x;
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            canvas.SetActive(true);
        }
    }
}