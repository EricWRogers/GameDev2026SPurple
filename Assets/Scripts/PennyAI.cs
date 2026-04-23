using UnityEngine;

public class PennyAI : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    float sign = -1.0f;
    public float speed = 1.0f;
    public int counter = 100;
    public int maxCount = 100;
    public PlayerController playerController;
    public GameObject player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!playerController.flipped) {
            rb.linearVelocityX = sign * speed;
            counter--;
            if (counter <= 0)
            {
                counter = maxCount;
                sign *= -1;
            }
        }
    }
}
