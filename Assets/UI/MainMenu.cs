using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        
        var buttonStart = root.Q<Button>("StartButton");
        var buttonOptions = root.Q<Button>("OptionsButton");
        
        buttonStart.clicked += () =>
        {
            Debug.Log("Start button clicked");
            SceneManager.LoadScene("Scene1");
        };
        
        buttonOptions.clicked += () =>
        {
            Debug.Log("Options button clicked");
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
