using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlappyMovementBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float jumpPower;
    public int score;
    public GameObject playButton;
    public GameObject gameOver;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        rb = GetComponent<Rigidbody2D>();
        Pause();
    }

    public void Play()
    {
        score = 0;
        gameOver.SetActive(false);
        playButton.SetActive(false);
        Time.timeScale = 1f;
        this.enabled = true;
        rb.simulated = true; // Allow physics to function
        rb.velocity = Vector2.zero;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        this.enabled = false;
        rb.simulated = false; // Disable physics
    }

    public void GameOver()
    {
        gameOver.SetActive(true);
        playButton.SetActive(true);
        Pause();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && this.enabled)
        {
            rb.velocity = Vector2.up * jumpPower;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Call GameOver and then reload the scene
        GameOver();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        score++;
    }
}