using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuElement : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        var buttonStart = root.Q<Button>("StartButton");
        var buttonQuit = root.Q<Button>("QuitButton");

        buttonStart.clicked += () =>
        {
            Debug.Log("Start button clicked");

            var levelName = "Maze" + Random.Range(1, 3);
            ;

            Debug.Log("Loading Level: " + levelName);

            SceneManager.LoadScene(levelName);
        };

        buttonQuit.clicked += () =>
        {
            Debug.Log("Quit button clicked");
            Application.Quit();
        };
    }
}