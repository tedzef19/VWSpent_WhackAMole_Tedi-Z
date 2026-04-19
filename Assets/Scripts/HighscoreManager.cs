using UnityEngine;
using TMPro;

public class HighscoreManager : MonoBehaviour
{
    public TextMeshProUGUI highscoreText;

    private void Start()
    {
        int highscore = PlayerPrefs.GetInt("HighScore", 0);
        if (highscoreText) highscoreText.text = "Highscore: " + highscore;
    }
}