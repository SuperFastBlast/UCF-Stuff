using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrGeRandomize : MonoBehaviour {

    public GameObject obj;
    private Rigidbody2D rb;
    
	void Start () {
        
        rb = obj.GetComponent<Rigidbody2D>();
        Vector2 randpos = new Vector2(Random.Range(-50f, 50f), Random.Range(50f, -50f));
        rb.AddForce(randpos);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
