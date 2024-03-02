using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{   
    [SerializeField]
    
   
    // Start is called before the first frame update
    void Start()
    {
        
    }
  void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(""+Key.keyCount);
        if (other.gameObject.tag=="Fire"){
        Debug.Log("Fire");
        Destroy(gameObject);
        SceneManager.LoadScene("Main Menu");}

    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
