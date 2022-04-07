using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_gameOverText;
    [SerializeField] TextMeshProUGUI m_timerText;
    [SerializeField] Score m_playerScore;
    [SerializeField] Score m_opponentScore;
    [SerializeField] float m_gameTimeInSeconds = 60f;
    float m_timer;
    bool m_gameIsPlaying = false;
    public static float RespawnHeight = 0.25f;

    void Start()
    {
        Time.timeScale = 0f;
        m_timer = m_gameTimeInSeconds;
        UpdateTimer();
    }

    void FixedUpdate()
    {
        if (!m_gameIsPlaying) return;

        m_timer -= Time.fixedDeltaTime;
        if (m_timer <= 0)
        {
            GameOver();
            m_timer = 0;
        }

        UpdateTimer();
    }

    void UpdateTimer()
    {
        // {0:0}:{1:00}
        // first number (0 and 1) is the index
        // : separates the index and the formatting
        // the 0 are leading zeros
        m_timerText.text = string.Format("{0:0}:{1:00}", Mathf.Floor(m_timer / 60), Mathf.Floor(m_timer % 60));
    }

    void GameOver()
    {
        m_gameIsPlaying = false;
        Time.timeScale = 0f;

        string gameovertext;
        if (m_playerScore.ScoreValue > m_opponentScore.ScoreValue)
            gameovertext = "YOU WIN!";
        else if (m_playerScore.ScoreValue < m_opponentScore.ScoreValue)
            gameovertext = "YOU LOSE!";
        else
            gameovertext = "TIE!";

        m_gameOverText.text = gameovertext + "\n\nPress SPACE to Restart";
        m_gameOverText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        if (!m_gameIsPlaying)
        {
            Time.timeScale = 1f;
            m_gameOverText.gameObject.SetActive(false);
            m_timer = m_gameTimeInSeconds;
            m_gameIsPlaying = true;
        }
    }
}
