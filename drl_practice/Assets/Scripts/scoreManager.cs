using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scoreManager : MonoBehaviour
{
    public TextMeshProUGUI score_t;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        score_t.text = "Points: "+score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
