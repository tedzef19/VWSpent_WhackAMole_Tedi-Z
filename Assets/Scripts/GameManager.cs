using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public enum GameState { Idle, Running, Ended }
    public GameState currentState = GameState.Idle;

    public float roundDuration = 45f;
    public float currentTime = 0f;

    public int currentScore = 0;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public GameObject gameOverPanel;

    public UnityEvent onGameStart;
    public UnityEvent onGameEnd;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        if (currentState == GameState.Running)
        {
            currentTime += Time.deltaTime;
            if (timerText) timerText.text = Mathf.Ceil(roundDuration - currentTime).ToString();

            if (currentTime >= roundDuration)
            {
                EndRound();
            }
        }
    }

    public void StartRound()
    {
        if (currentState != GameState.Idle) return;

        currentState = GameState.Running;
        currentScore = 0;
        currentTime = 0f;
        UpdateScoreUI();

        if (gameOverPanel) gameOverPanel.SetActive(false);

        onGameStart?.Invoke();
    }

    public void EndRound()
    {
        currentState = GameState.Ended;
        onGameEnd?.Invoke();

        if (gameOverPanel) gameOverPanel.SetActive(true);
        if (currentScore > PlayerPrefs.GetInt("HighScore", 0))
        PlayerPrefs.SetInt("HighScore", currentScore);

        // Freeze everything + auto reset after 5 seconds
        Invoke("AutoReset", 5f);
    }

    private void AutoReset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int points = 10)
    {
        if (currentState != GameState.Running) return;
        currentScore += points;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText) scoreText.text = "Score: " + currentScore;
    }

    public void ResetGame()
    {
        currentState = GameState.Idle;
        currentScore = 0;
        currentTime = 0f;
        UpdateScoreUI();
        if (gameOverPanel) gameOverPanel.SetActive(false);
    }
}