using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BrGeController : MonoBehaviour
{

    public GameObject ball;
    public GameObject paddle;
    float moveHorizontal;
    float moveVertical;
    private Rigidbody2D rb2d;
    public float speed;
    public float jumpforce;
    private Vector2 movement;
    private float timer;
    private int score;
    public Text scoreText;
    public Text endText;
    private bool lose;
    private bool win;
    public AudioClip jump;
    AudioSource audioSour1;
    private bool isJump;
    public AudioClip die;
    private bool hasPlayed;
    public AudioClip intro;
    private bool isAlive;
    void SetCountText()
    {
        scoreText.text = "Score: " + score.ToString();

        if (score >= 10 && lose != true)
        {
            score = 10;
            win = true;
           // GameLoader.AddScore(score);
            endText.text = "You balanced for "+score+" seconds!";
            
        }
    }

    // Use this for initialization
    void Start()
    {
        rb2d = ball.GetComponent<Rigidbody2D>();
        endText.text = " ";
        hasPlayed = false;
        isAlive = true;
        
        audioSour1 = GetComponent<AudioSource>();
        audioSour1.PlayOneShot(intro);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");

        // moveVertical = Input.GetAxis("Vertical");

        movement = new Vector2(moveHorizontal, 0f) * speed;


            if (Input.GetKeyDown(KeyCode.UpArrow) && isJump != true)
            {
                // rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
                rb2d.velocity = Vector2.up * jumpforce;
                audioSour1.PlayOneShot(jump, 0.6f);
                isJump = true;
                


            }

 
        isJump = false;
        rb2d.AddForce(movement * speed);









        timer = timer + Time.deltaTime;
        if(ball.gameObject.activeSelf == true)
        {
            score = (int)timer;
            if (score >= 10)
            {
                score = 10;
            }
        }
        if(ball.gameObject.activeSelf == false && win != true)
        {
            lose = true;
            isAlive = false;
            if (!audioSour1.isPlaying && hasPlayed == false)
            {
                hasPlayed = true;
                audioSour1.PlayOneShot(die);
                Debug.Log("plays");
            }
            // GameLoader.AddScore(score);
            endText.fontSize = 20;
            if (score == 1) { endText.text = "You balanced for " + score + " second!"; } 
            else { endText.text = "You balanced for " + score + " " + "seconds!"; }
            
        }
        
        SetCountText();
        if (timer >= 10)
        {
            StartCoroutine(ByeAfterDelay(2));


        }


    }

    IEnumerator ByeAfterDelay(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        //  GameLoader.gameOn = false;
    }


}
