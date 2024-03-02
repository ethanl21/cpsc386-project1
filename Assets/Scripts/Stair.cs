using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;
public class Stair : MonoBehaviour
{
    [SerializeField]
    // Start is called before the first frame update
    void Start()
    {
        
}
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Test");
        Scene scene = SceneManager.GetActiveScene();
        //Debug.Log("Active Scene is " + scene.name);
    
        if(other.gameObject.tag == "Player")
        {   Debug.Log("STAIR");
        if (scene.name =="Scene1")
            SceneManager.LoadScene("Scene2");
        if (scene.name =="Scene2")
            SceneManager.LoadScene("Scene1");
        }}
    // Update is called once per frame
    void Update()
    {
        
    }
}
