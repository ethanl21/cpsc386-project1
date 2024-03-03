using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameHUD : MonoBehaviour
{
    private UIDocument _root;
    private VisualElement _gameHUDBox;
    private VisualElement _gameResultBox;
    
    private Label _timeLabel;
    private Label _keysLabel;

    public float currentTime = 0;
    public int keyCount = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        _root = GetComponent<UIDocument>();
        
        _gameHUDBox = _root.rootVisualElement.Q<VisualElement>("HUDBox");
        _gameResultBox = _root.rootVisualElement.Q<VisualElement>("EndScreenBox");
        
        _timeLabel = _root.rootVisualElement.Q<Label>("TimerLabel");
        _keysLabel = _root.rootVisualElement.Q<Label>("KeyCountLabel");
        
        _root.rootVisualElement.Q<Button>("MainMenuButton").clicked += () => SceneManager.LoadScene("Main Menu");
    }

    // Update is called once per frame
    void Update()
    {
        // update the time label and key count
        var timespan = TimeSpan.FromSeconds(currentTime);
        _timeLabel.text = "Time: " + timespan.Minutes + ":" + timespan.Seconds + ":" + timespan.Milliseconds;
        _keysLabel.text = "x" + keyCount;
    }
    
    public void ShowEndScreen(float highScore, float currentScore, bool hasHighScore)
    {
        _gameHUDBox.style.display = DisplayStyle.None;
        
        var highScoreTimeSpan = TimeSpan.FromSeconds(highScore);
        var currentTimeSpan = TimeSpan.FromSeconds(currentScore);
        
        var highScoreLabel = _root.rootVisualElement.Q<Label>("HighScoreLabel");
        highScoreLabel.text = "High Score: " +  highScoreTimeSpan.Minutes + ":" + highScoreTimeSpan.Seconds + ":" + highScoreTimeSpan.Milliseconds;
        
        var currentScoreLabel = _root.rootVisualElement.Q<Label>("ScoreLabel");
        currentScoreLabel.text = "Your Score: " + currentTimeSpan.Minutes + ":" + currentTimeSpan.Seconds + ":" + currentTimeSpan.Milliseconds;
        if (hasHighScore)
        {
            currentScoreLabel.text += " (New Record!)";
        }
        
        _gameResultBox.visible = true;
    }
}
