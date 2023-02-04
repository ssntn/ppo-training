using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score_t;
    private int score;
    public int p_score {set {AddScore();}}

    void Start()
    {
        ResetScore();
    }

    void Update(){}

    public void AddScore(){
        score++;
        SetScoreText(score);
    }
    public void ResetScore()
    {
        score = 0;
        SetScoreText(score);
    }

    private void SetScoreText(int score)
    {
        score_t.text = "Points: " + score.ToString();
    }
}
