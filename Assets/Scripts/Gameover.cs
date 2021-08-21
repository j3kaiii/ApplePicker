using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameover : MonoBehaviour
{
    int bestScore = 0;
    int currentScore = 0;

    Text currentText;
    Text bestText;

   
    // Start is called before the first frame update
    void Start()
    {
        currentScore = Values.currentCount;
        if (PlayerPrefs.HasKey("HighScores"))
        {
            bestScore = PlayerPrefs.GetInt("HighScores");
        }

        currentText = GameObject.Find("PlayerScores").GetComponent<Text>();
        bestText = GameObject.Find("HighScores").GetComponent<Text>();

        
    }

    private void Update()
    {
        currentText.text = "Your score : " + currentScore.ToString();
        bestText.text = "High score : " + bestScore.ToString();
    }

    public void TryAgain()
    {
        SceneManager.LoadScene("ApplePicker");
    }
}
