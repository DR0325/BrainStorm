using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LevelClearInfo : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI starsText;
    public void Setup(int score, float time, int stars, int totalStars)
    {
        gameObject.SetActive(true);
        scoreText.text = "Score: " + score.ToString();
        timeText.text = "Time: " + time.ToString();
        starsText.text = "Stars: " + stars.ToString() + " / " + totalStars.ToString();
    }
}
