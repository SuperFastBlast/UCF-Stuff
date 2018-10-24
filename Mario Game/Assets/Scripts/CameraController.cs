using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform player;

    // Use this for initialization
    void Start () {
		
	}
	
    void LateUpdate()
    {
        transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);

    }

    // Update is called once per frame
    void Update () {
		
	}
}
