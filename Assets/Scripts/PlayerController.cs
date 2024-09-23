//Sam Hennessey 9/22/24
//Script for the player object controlling movement and functions.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    private float timer = 60.0f;
    public int lives = 3;
    public Text timerText;
    public Text winText;
    public Text livesText;
    public Button restartButton;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        timerText.text = "Timer: " + Mathf.Floor(timer).ToString();
        winText.text = "";
        livesText.text = "Lives: " + lives.ToString();
        restartButton.gameObject.SetActive(false); //hide button
    }

        void Update()
    {
        if (timer > 0) //loop for timer
        {
            timer -= Time.deltaTime;
            timerText.text = "Timer: " + Mathf.Floor(timer).ToString();
        }

        if (timer <= 0 && winText.text == "")  //win condition, you make it 60 sec
        {
            winText.text = "You Win!";
            Time.timeScale = 0;
            restartButton.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame, FixedUpdate is in synch with physics engine
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.velocity = movement * speed;       //velocity movement
    }
    private void OnCollisionEnter2D(Collision2D other) // changed it to game over if player runs out of lives
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            lives--;
            livesText.text = "Lives: " + lives.ToString(); //loses life on collison

            if (lives <= 0)
            {
            winText.text = "Game Over!";
            Time.timeScale = 0;
            restartButton.gameObject.SetActive(true); //game over once out of lives
            }
        }
    }

    public void onRestart() //restart function
    {
        Time.timeScale = 1; // Reset time scale to normal
        SceneManager.LoadScene("SampleScene"); //restart the game
    }
}
