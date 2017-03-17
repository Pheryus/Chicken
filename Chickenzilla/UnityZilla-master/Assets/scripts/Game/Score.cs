using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    private int highscore;
    private int actual_score;
    private int score;
    void Start()
    {
        highscore = PlayerPrefs.GetInt("HighScore", 0);
        InvokeRepeating("AddOneScore", 1.0f, 1.0f);
    }

    public void AddOneScore()
    {
        actual_score += 1;
    }

    public int GetScore() {
        return actual_score;
    }

    public void AddScore(int i=1)
    {
        actual_score += i;
        if (actual_score < 0)
            actual_score = 0;
    }



    private void UpdateTextUI()
    {
        if (actual_score != score) {
            score = actual_score;
            gameObject.GetComponent<Text>().text = "" + actual_score.ToString("0000000");
        }

    }

	void FixedUpdate () {
        UpdateTextUI();
	}

    void OnDisable()
    {

        //If our scoree is greter than highscore, set new higscore and save.
        if (actual_score > highscore)
        {
            PlayerPrefs.SetInt("HighScore", actual_score);
            PlayerPrefs.Save();
        }
    }

}
