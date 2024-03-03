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
        var buttonQuit = root.Q<Button>("QuitButton");
        
        buttonStart.clicked += () =>
        {
            Debug.Log("Start button clicked");

            var prefix = "Maze";
            prefix += Random.Range(1, 3);
            
            Debug.Log("Loading Level: " + prefix);

            SceneManager.LoadScene(prefix);
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