using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI scoreText;

    public int score = 0;
    public bool gameStarted = false;
    public bool gameOver = false;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        score = 0;
        scoreText.text = "0";
        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        gameStarted = true;
    }

    public void AddScore()
    {
        if (gameOver) return;

        score++;
        scoreText.text = score.ToString(); 
    }

    public void EndGame()
    {
        if (gameOver) return;

        gameOver = true;
        Debug.Log("Game Over");

        Invoke(nameof(RestartGame), 1.5f);
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}