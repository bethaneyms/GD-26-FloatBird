using UnityEngine;

public class BirdBehavior : MonoBehaviour
{
    public float jumpForce = 5f;

    public AudioSource flapSound;
    public AudioSource hitSound;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void Update()
    {
        if (GameManager.instance == null) return;
        if (GameManager.instance.gameOver) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (!GameManager.instance.gameStarted)
            {
                GameManager.instance.StartGame();
                rb.gravityScale = 3f;
            }

            rb.linearVelocity = Vector2.up * jumpForce;

            if (flapSound != null)
            {
                flapSound.Play();
            }
        }

        if (transform.position.y < -6f)
        {
            if (hitSound != null && !hitSound.isPlaying)
            {
                hitSound.Play();
            }

            GameManager.instance.EndGame();
        }
    }

    void FixedUpdate()
    {
        if (rb == null) return;

        if (GameManager.instance != null && GameManager.instance.gameOver)
            return;

        if (rb.linearVelocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 20f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 0f, -45f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.instance == null) return;
        if (GameManager.instance.gameOver) return;

        Debug.Log("Collided with: " + collision.gameObject.name);

        if (hitSound != null)
        {
            hitSound.Play();
        }

        GameManager.instance.EndGame();
    }
}