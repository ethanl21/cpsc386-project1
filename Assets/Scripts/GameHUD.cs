using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GameHUD : MonoBehaviour
{
    public float currentTime;
    public int keyCount;
    private VisualElement _gameHUDBox;
    private VisualElement _gameResultBox;
    private Label _keysLabel;
    private UIDocument _root;

    private Label _timeLabel;

    // Start is called before the first frame update
    private void Start()
    {
        _root = GetComponent<UIDocument>();

        _gameHUDBox = _root.rootVisualElement.Q<VisualElement>("HUDBox");
        _gameResultBox = _root.rootVisualElement.Q<VisualElement>("EndScreenBox");

        _timeLabel = _root.rootVisualElement.Q<Label>("TimerLabel");
        _keysLabel = _root.rootVisualElement.Q<Label>("KeyCountLabel");

        _root.rootVisualElement.Q<Button>("MainMenuButton").clicked += () => SceneManager.LoadScene("Main Menu");
    }

    // Update is called once per frame
    private void Update()
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
        highScoreLabel.text = "High Score: " + highScoreTimeSpan.Minutes + ":" + highScoreTimeSpan.Seconds + ":" +
                              highScoreTimeSpan.Milliseconds;

        var currentScoreLabel = _root.rootVisualElement.Q<Label>("ScoreLabel");
        currentScoreLabel.text = "Your Score: " + currentTimeSpan.Minutes + ":" + currentTimeSpan.Seconds + ":" +
                                 currentTimeSpan.Milliseconds;
        if (hasHighScore) currentScoreLabel.text += " (New Record!)";

        _gameResultBox.visible = true;
    }

    public void ShowGameOver()
    {
        // Change EndTitleLabel to "Game Over!"
        _root.rootVisualElement.Q<Label>("EndTitleLabel").text = "Game Over!";

        // Hide ScoreContainer
        _root.rootVisualElement.Q<VisualElement>("ScoreContainer").style.display = DisplayStyle.None;

        _gameResultBox.visible = true;
    }
}