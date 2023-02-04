using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score_t;
    private int score;
    public int p_score {set {AddScore();}}

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        score_t.text = "Points: "+score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(){
        score++;
        score_t.text = "Points: "+score.ToString();
    }
}
