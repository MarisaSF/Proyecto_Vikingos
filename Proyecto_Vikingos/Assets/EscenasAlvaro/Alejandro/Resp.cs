using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resp : MonoBehaviour {

    public Transform resp;
    Transform player;
 // public  Transform  camara;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.position = resp.position;
            player.rotation = resp.rotation;
           // camara.position = resp.position;
        }
    }
}
