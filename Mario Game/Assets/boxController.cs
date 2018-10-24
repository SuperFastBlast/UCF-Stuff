using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class boxController : MonoBehaviour {

    public GameObject player;

    public LayerMask isGround;
    private static int score;
    public Transform wallHitBox;
    public Text countText;
    public Text winText;
    private bool wallHit;
    public AudioClip die;
    AudioSource audioSour;
    private int numOfCoins = 2;
    private bool playerHit;
    public float wallHitHeight;
    public float wallHitWidth;
    // Use this for initialization
    void Start () {
		
	}

    void FixedUpdate()
    {
        wallHit = Physics2D.OverlapBox(wallHitBox.position, new Vector2(wallHitWidth, wallHitHeight), 0, isGround);
        if (wallHit == true)
        {
            

        }



    }
    void SetCountText()
    {
        countText.text = "Score: " + PlayerController.count.ToString();

        if (PlayerController.count >= 18)
            winText.text = "You win!";
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && player.transform.position.y < gameObject.transform.position.y && numOfCoins > 1)
        {
            PlayerController.count = PlayerController.count + 1;
            SetCountText();
            numOfCoins--;
        }


    }
    // Update is called once per frame
    void Update () {
		
	}
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(wallHitBox.position, new Vector3(wallHitWidth, wallHitHeight, 1));
    }
}
