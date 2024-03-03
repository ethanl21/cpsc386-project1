using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class Player : MonoBehaviour
{
    public static int keyCount = 0;
    
    private UIDocument _uiDocument;

    private Label _timeLabel;
    private float _currentTime;

    private Label _keyLabel;
    
   
    // Start is called before the first frame update
    void Start()
    {
        _uiDocument = GameObject.Find("HUDElement").GetComponent<UIDocument>();

        var root = _uiDocument.rootVisualElement;
        _timeLabel = root.Q<Label>("TimerLabel");
        
        _keyLabel = root.Q<Label>("KeyCountLabel");
    }
    
  void OnCollisionEnter2D(Collision2D other)
    {
        // Debug.Log(""+Key.keyCount);
        // if (other.gameObject.tag=="Fire"){
        // Debug.Log("Fire");
        // Destroy(gameObject);
        // SceneManager.LoadScene("Main Menu");}
        
        Debug.Log("Collision detected");
        if (other.gameObject.CompareTag("Door"))
        {
            if (keyCount > 0)
            {
                keyCount -= 1;
                Destroy(other.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            keyCount += 1;
            Destroy(other.gameObject);
        }else if (other.gameObject.CompareTag("Fire"))
        {
            Debug.Log("Fire");
            Destroy(gameObject);
            SceneManager.LoadScene("Main Menu");
        } else if (other.gameObject.CompareTag("Finish"))
        {
            // game is finished
            Debug.Log("Reached Goal!");
            SceneManager.LoadScene("Main Menu");
        }else if (other.gameObject.CompareTag("PowerUp"))
        {
            GameObject.Find("Camera").GetComponent<Camera>().fieldOfView *= 2;
            Destroy(other.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;
        var timespan = TimeSpan.FromSeconds(_currentTime);
        _timeLabel.text = "Time: " + timespan.Minutes + ":" + timespan.Seconds + ":" + timespan.Milliseconds;
        
        _keyLabel.text = "x" + keyCount;
    }
}
