using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    // Key count of the player
    private static int _keyCount;

    // Movement speed of the player, set in the inspector
    public float moveSpeed = 4f;
    private float _currentTime;

    // Shows the player their score and keys using UI elements
    private GameHUD _hud;

    // Used to move the player
    private Vector2 _moveDir;
    private Rigidbody2D _movingBody;

    // Used to keep track of the user's running time
    private bool _timerRunning = true;

    // Start is called before the first frame update
    private void Start()
    {
        _hud = GameObject.Find("GameHUD").GetComponent<GameHUD>();
        _movingBody = GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    private void Update()
    {
        if (!_timerRunning) return;
        _currentTime += Time.deltaTime;

        _hud.currentTime = _currentTime;
        _hud.keyCount = _keyCount;
    }

    // from InputExample.cs
    private void FixedUpdate()
    {
        _movingBody.AddForce(_moveDir * (moveSpeed * Time.deltaTime * 100f), ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Debug.Log(""+Key.keyCount);
        // if (other.gameObject.tag=="Fire"){
        // Debug.Log("Fire");
        // Destroy(gameObject);
        // SceneManager.LoadScene("Main Menu");}

        Debug.Log("Collision detected");
        if (other.gameObject.CompareTag("Door"))
        {
            if (_keyCount > 0)
            {
                _keyCount -= 1;
                Destroy(other.gameObject);
            }
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            _timerRunning = false;
            _hud.ShowGameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Key"))
        {
            _keyCount += 1;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Fire"))
        {
            _timerRunning = false;
            _hud.ShowGameOver();
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            // game is finished
            Debug.Log("Reached Goal!");
            _timerRunning = false;

            // compare high score
            var highScore = PlayerPrefs.GetFloat("HighScore", _currentTime);
            var hasHighScore = _currentTime <= highScore;
            if (hasHighScore)
            {
                PlayerPrefs.SetFloat("HighScore", _currentTime);
                highScore = _currentTime;
            }

            _hud.ShowEndScreen(highScore, _currentTime, hasHighScore);
        }
        else if (other.gameObject.CompareTag("PowerUp"))
        {
            if (other.gameObject.GetComponent<PowerUp>().powerUpType == "Camera")
                GameObject.Find("Camera").GetComponent<Camera>().fieldOfView *= 2;

            Destroy(other.gameObject);
        }
    }

    // from InputExample.cs
    private void OnMove(InputValue value)
    {
        if (_timerRunning) _moveDir = value.Get<Vector2>() * moveSpeed;
    }
}