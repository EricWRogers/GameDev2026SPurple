using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    public UnityEvent flipFlop;
    public GameObject[] flipableObjects;
    public GameObject[] enemies;
    AudioSource audioSource;
    InputAction moveAction;
    InputAction jumpAction;
    Vector2 moveValue;
    Vector2 jumpForce;
    bool jumpValue;
    Rigidbody2D rb;
    public float forceMultiplier = 10;
    public float jumpMultiplier = 20;
    public float cooldown = 10;
    public float maxCooldown = 10;
    public float flipCooldown = 0;
    public float maxFlipCooldown = 520;
    public bool flipped = false;
    public int deaths = 0;
    public GameObject canvas;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 0.1f;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        moveValue.x = moveAction.ReadValue<Vector2>().x;
        jumpValue |= jumpAction.WasPressedThisFrame();
    }
    void FixedUpdate()
    {
        Debug.Log(flipped);
        rb.AddForce(moveValue * forceMultiplier);
        rb.linearVelocityX = rb.linearVelocityX * 0.85f;
        if (jumpValue && IsGrounded())
        {
            audioSource.PlayOneShot(audioClips[0]);
            rb.AddForce(new Vector2(0.0f, jumpMultiplier));
            jumpValue = false;
        }
        if (cooldown > 0)
        {
            cooldown--;
        }
        if (flipCooldown > 1) flipCooldown--;
        else if (flipCooldown == 1)
        {
            flipFlop.Invoke();
            flipCooldown = 0;
        }
    }
    bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && cooldown <= 0 && !flipped)
        {
            flipFlop.Invoke();
            flipCooldown = maxFlipCooldown;
            cooldown = maxCooldown;
            deaths++;
        }
    }

    public void flipWorld()
    {
        flipableObjects = GameObject.FindGameObjectsWithTag("Flipable");
        foreach (GameObject gameObject in flipableObjects)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = !gameObject.GetComponent<SpriteRenderer>().enabled;
            gameObject.GetComponent<BoxCollider2D>().enabled = !gameObject.GetComponent<BoxCollider2D>().enabled;
        }
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        flipped = !flipped;//Please work bro
    }
}