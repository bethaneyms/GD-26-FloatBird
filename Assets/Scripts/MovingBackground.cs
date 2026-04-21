using UnityEngine;

public class MovingBackground : MonoBehaviour
{
    public float speed = 50f;
    public float resetX = -1000f;
    public float startX = 1000f;

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (GameManager.instance == null) return;
        if (!GameManager.instance.gameStarted) return;
        if (GameManager.instance.gameOver) return;

        rectTransform.anchoredPosition += Vector2.left * speed * Time.deltaTime;

        if (rectTransform.anchoredPosition.x <= resetX)
        {
            rectTransform.anchoredPosition = new Vector2(startX, rectTransform.anchoredPosition.y);
        }
    }
}