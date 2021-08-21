using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{
    public static int score = 0;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("HighScores"))
        {
            score = PlayerPrefs.GetInt("HighScores");
        }
        PlayerPrefs.SetInt("HighScores", score);
    }
    void Update()
    {
        Text gt = this.GetComponent<Text>();
        gt.text = "High score : " + score;

        if (score > PlayerPrefs.GetInt("HighScores"))
        {
            PlayerPrefs.SetInt("HighScores", score);
        }
    }
}
