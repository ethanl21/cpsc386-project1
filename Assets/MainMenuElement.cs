using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuElement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        
        var buttonStart = root.Q<Button>("StartButton");
        var buttonOptions = root.Q<Button>("OptionsButton");
        var buttonQuit = root.Q<Button>("QuitButton");
        
        buttonStart.clicked += () =>
        {
            Debug.Log("Start button clicked");
            SceneManager.LoadScene("Maze1");
        };
        
        buttonOptions.clicked += () =>
        {
            Debug.Log("Options button clicked");
        };
        
        buttonQuit.clicked += () =>
        {
            Debug.Log("Quit button clicked");
            Application.Quit();
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}