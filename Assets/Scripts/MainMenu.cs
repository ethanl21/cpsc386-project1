using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void QuitGame()
    {Application.Quit();}

    public void Scene(string sceneName){
        SceneManager.LoadScene(sceneName);
        Key.keyCount=0;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
