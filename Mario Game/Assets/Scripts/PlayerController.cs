using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody2D rb2d;
    private bool facingRight = true;

    private Animator anim; 

    public float speed;
    public float jumpforce;

    //ground check
    private bool isOnGround;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask allGround;
    public Text countText;
    public Text winText;
    public static int count;
    // private float jumpTimeCounter;
    //public float jumpTime;
    //private bool isJumping;

    //audio stuff
    public AudioClip jump;
    AudioSource audio;

    void SetCountText()
    {
        countText.text = "Score: " + count.ToString();

        if (count >= 18)
            winText.text = "You win!";
    }

    // Use this for initialization
    void Start()
    {
        audio = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }   
	

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {

            other.gameObject.SetActive(false);

            count = count + 1;

            SetCountText();
        }
    }




void Awake()
    {

       // source = GetComponent<AudioSource>();

    }

    private void Update(){
       
    }

    
    // Update is called once per frame
    void FixedUpdate () {

        float moveHorizontal = Input.GetAxis("Horizontal");

        //Vector2 movement = new Vector2(moveHorizontal, 0);

       // rb2d.AddForce(movement * speed);

        rb2d.velocity = new Vector2(moveHorizontal * speed, rb2d.velocity.y);

        isOnGround = Physics2D.OverlapCircle(groundcheck.position, checkRadius, allGround);

        Debug.Log(isOnGround);

        if(moveHorizontal == 0)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isJumping", false);
            anim.SetBool("isIdle", true);
        }
        if (moveHorizontal > 0 || moveHorizontal < 0 && isOnGround)
        {
            anim.SetBool("isRunning", true);
            anim.SetBool("isJumping", false);
            anim.SetBool("isIdle", false);

        }
        if(!isOnGround)
        {
            //anim.SetBool("isJumping", true);
        }

        //stuff I added to flip my character
        if (facingRight == false && moveHorizontal > 0)
        {
            Flip();
        }
        else if(facingRight == true && moveHorizontal < 0)
        {
            Flip();
        }
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground" && isOnGround)
        {


            if (Input.GetKey(KeyCode.UpArrow))
            {
               // rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
               rb2d.velocity = Vector2.up * jumpforce;
                anim.SetBool("isJumping", true);


                // Audio stuff
                
                audio.PlayOneShot(jump,0.6F);



            }
        }
    }
}
