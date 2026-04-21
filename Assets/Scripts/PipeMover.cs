using UnityEngine;

public class PipeMover : MonoBehaviour
{
    void Update()
    {
        if (GameManager.instance == null) return;
        if (!GameManager.instance.gameStarted) return;
        if (GameManager.instance.gameOver) return;

        transform.position += Vector3.left * GameManager.instance.pipeSpeed * Time.deltaTime;

        if (transform.position.x < -15f)
        {
            Destroy(gameObject);
        }
    }
}