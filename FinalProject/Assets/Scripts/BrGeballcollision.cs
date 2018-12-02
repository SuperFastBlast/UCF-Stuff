using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrGeballcollision : MonoBehaviour {

    public GameObject ball;
    public GameObject particle;
    public AudioClip die;
    AudioSource audioSour12;

    // Use this for initialization
    void Start () {
        audioSour12 = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
          
            
            particle = Instantiate(particle, transform.position, Quaternion.identity);
            
            ball.gameObject.SetActive(false);
           
            
            Destroy(particle, 3);

        }
    }
}
