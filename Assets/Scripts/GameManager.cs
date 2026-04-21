using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public TextMeshProUGUI scoreText;
    public GameObject startText;

    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;

    public int score = 0;
    public bool gameStarted = false;
    public bool gameOver = false;

    public float pipeSpeed = 3f;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        score = 0;
        gameStarted = false;
        gameOver = false;
        pipeSpeed = 3f;

        if (scoreText != null) scoreText.text = "0";
        if (startText != null) startText.SetActive(true);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void StartGame()
    {
        if (gameOver) return;

        gameStarted = true;

        if (startText != null)
        {
            startText.SetActive(false);
        }
    }

    public void AddScore()
    {
        if (gameOver) return;

        score++;

        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }

        if (score % 10 == 0)
        {
            pipeSpeed += 0.5f;
        }
    }

    public void EndGame()
    {
        if (gameOver) return;

        gameOver = true;

        if (startText != null)
        {
            startText.SetActive(false);
        }

        int highScore = PlayerPrefs.GetInt("HighScore", 0);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        if (finalScoreText != null)
        {
            finalScoreText.text = "Score: " + score;
        }

        if (highScoreText != null)
        {
            highScoreText.text = "Best: " + highScore;
        }

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }

        StartCoroutine(PauseAfterDelay());
    }

    private IEnumerator PauseAfterDelay()
    {
        yield return new WaitForSecondsRealtime(0.15f);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}