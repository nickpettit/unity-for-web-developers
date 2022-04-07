using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI m_scoreText;
    public int ScoreValue { get; private set; }

    void FixedUpdate()
    {
        m_scoreText.text = ScoreValue.ToString();
    }

    public void ResetScore()
    {
        ScoreValue = 0;
    }

    public void IncrementScore()
    {
        ScoreValue++;
    }
}
