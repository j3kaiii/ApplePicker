using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Basket : MonoBehaviour
{
    public Text scoreText;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("Count");
        scoreText = scoreGO.GetComponent<Text>();
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos2d = Input.mousePosition;
        Vector2 pos = this.transform.position;
        Vector2 mPos = Camera.main.ScreenToWorldPoint(mousePos2d);
        pos.x = mPos.x;
        this.transform.position = pos;
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject collideWith = coll.gameObject;
        if (collideWith.tag == "Apple")
        {
            Destroy(collideWith);

            int score = int.Parse(scoreText.text);
            score++;
            scoreText.text = score.ToString();
            Values.currentCount = score;

            if (score > HighScores.score)
            {
                HighScores.score = score;
            }
        }
    }
}
