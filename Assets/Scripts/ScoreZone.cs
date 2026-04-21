using UnityEngine;

public class ScoreZone : MonoBehaviour
{
    public AudioSource pointSound;

    private bool scored = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (GameManager.instance == null) return;

        if (!scored && other.CompareTag("Player"))
        {
            scored = true;
            GameManager.instance.AddScore();

            if (pointSound != null)
            {
                pointSound.Play();
            }

            Debug.Log("Scored!");
        }
    }
}