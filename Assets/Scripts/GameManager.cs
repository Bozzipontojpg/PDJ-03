using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [SerializeField]
    private SnakeManager snakeManager;
    [SerializeField]
    private DotFactory dotFactory;
    [SerializeField]
    private WindowManager windowManager;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    private int points;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
        
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        dotFactory.SpawnDot();
        snakeManager.StartGame();
        windowManager.OpenWindow(1);
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    public void AddPoints(int points)
    {
        this.points += points;
        snakeManager.UpdatePoints(points);
        
        scoreText.text = this.points.ToString("000");
    }

    public void GameOver()
    {
        snakeManager.EndGame();
        dotFactory.DestroyDot();
        windowManager.OpenWindow(2);
        Time.timeScale = 0;
    }
}
