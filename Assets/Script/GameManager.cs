using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int Score;
    public Text ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        ScoreText.text = Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ScoreUpdate()
    {
        Score++;
        ScoreText.text = Score.ToString();
    }
}
