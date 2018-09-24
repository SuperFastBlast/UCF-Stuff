using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public Text scoreText;
    private Rigidbody rb;
    private int count;
    private int score;
    private bool lvl1 = false;
    private float playerPosx;
    private float playerPosy;
    private float playerPosz;
    private bool lvl2 = false;
    public Renderer rend;
    void Start()
    {


        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        SetScoreText();
        winText.text = "";
    }

    void Update ()
    {
        // Get X value. Convert to RGB 0-1 and multiply by 20 to get more vibrent colors
        playerPosx = Mathf.Abs((rb.transform.position.x) / 255.0f)*20;
        // Check to see if red value goes out of bounds. If it does use diffrent formula to keep it in bounds
        if(playerPosx > 1)
        {
          playerPosx = Mathf.Abs((rb.transform.position.x) / 255.0f) * 5;

        }
        playerPosy = Mathf.Abs((rb.transform.position.y) / 255.0f)*20;
        playerPosz = Mathf.Abs((rb.transform.position.z) / 255.0f)*20;
        // Get material from object and set it equal to our new RBG color.
        gameObject.GetComponent<Renderer>().material.color = new Color(playerPosx,0.0f,playerPosz);

        
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

       

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            score = score + 1;
            SetCountText();
            SetScoreText();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            score = score - 1;
            SetCountText();
            SetScoreText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 12)
        {
            lvl1 = true;
           
        }
        if (count == 22)
        {
            lvl2 = true;

        }
        if (lvl1 == true)
        {
            rb.transform.position = new Vector3(-30f,0.5f,1.5f);
            lvl1 = false;
            
        }
        if(lvl2 == true)
        {
            winText.text = "You Finished with a score of:" + score.ToString();
        }

    }
    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();

    }
}