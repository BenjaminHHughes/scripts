using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BouncyBall : MonoBehaviour
{
    public float minY = -5.5f;
    public float maxVelocity = 15f;

    Rigidbody2D rb;

    int score = 0;
    int lives = 5;

    public TextMeshProUGUI scoreTxt;
    public GameObject[] livesImage;

    public GameObject GameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < minY)
        {
            if (lives <= 0) //when you run out of lives, calls the game over function
            {
                GameOver();
            }
            else
            {
                transform.position = Vector3.zero; //resets ball when going below a certain y position
                rb.velocity = Vector3.zero;
                lives--;
                livesImage[lives].SetActive(false);
            }

        }

        if(rb.velocity.magnitude>maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity); //gives the ball a velocity cap so it stays playable
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)  //when the ball collides with a brick it destroys it and adds 10 score
    {
        if(collision.gameObject.CompareTag("Brick"))
        {
            Destroy(collision.gameObject);
            score +=10;
            scoreTxt.text = score.ToString("000");
        }
    }

    void GameOver()  //destroys the ball and displays a game over screen
    {
        GameOverPanel.SetActive(true);
        Time.timeScale = 0;
        Destroy(gameObject);
    }
}
