using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaController : MonoBehaviour {

    private Animator anim;

    public float speed;

    public GameObject player;

    public LayerMask isGround;

    public Transform wallHitBox;

    private bool wallHit;

    public AudioClip die;
    AudioSource audioSour;

    private bool playerHit;
    public float wallHitHeight;
    public float wallHitWidth;


	// Use this for initialization
	void Start () {
        playerHit = false;
        audioSour = GetComponent<AudioSource>();
        anim = GetComponent<Animator>(); 
	}
	
    void FixedUpdate()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);
        wallHit = Physics2D.OverlapBox(wallHitBox.position, new Vector2(wallHitWidth, wallHitHeight), 0, isGround);
        if(wallHit == true)
        {
            speed = speed * -1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && player.transform.position.y > gameObject.transform.position.y )
        {
         //   anim.SetBool("isDead", true);
            Destroy(gameObject);
        }

        else if (collision.collider.tag == "Player" && player.transform.position.y <= gameObject.transform.position.y)
        {
            player.gameObject.SetActive(false);
            audioSour.PlayOneShot(die, 0.6F);

        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(wallHitBox.position, new Vector3(wallHitWidth, wallHitHeight, 1));
    }
	// Update is called once per frame
	void Update () {
		
	}
}
