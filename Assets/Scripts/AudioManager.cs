using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioSource pointSound;

    void Awake()
    {
        instance = this;
    }

    public void PlayPoint()
    {
        if (pointSound != null)
        {
            pointSound.Play();
        }
    }
}