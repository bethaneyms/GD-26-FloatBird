using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdBehavior : MonoBehaviour
{
    public float jumpForce = 3f;
    private Rigidbody2D rb;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }

        if (transform.position.y < -6f || transform.position.y > 6f)
        {
            GameOver();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }

    void GameOver()
    {
        if (isDead) return;

        isDead = true;
        Debug.Log("Game Over");

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}