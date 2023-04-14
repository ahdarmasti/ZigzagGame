using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score, highScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score",score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncreaseScore()
    {
        score += 1;
        
    }
    
    void StartScore()
    {
        InvokeRepeating("IncreaseScore",0.1f,0.5f);
    }
    
    void StopScore()
    {
        CancelInvoke("startScore");
        PlayerPrefs.SetInt("score",score);

        if (PlayerPrefs.HasKey("highScore")) {
            if (score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else {
            PlayerPrefs.SetInt("highScore", score);
        }
        
        
    }
}