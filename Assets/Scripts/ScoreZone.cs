using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    private bool scored = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.instance == null) return;

        if (!scored && other.CompareTag("Player"))
        {
            scored = true;
            GameManager.instance.AddScore();

            AudioManager.instance.PlayPoint();

            Debug.Log("Scored!");
        }
    }
}