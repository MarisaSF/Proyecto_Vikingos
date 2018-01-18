using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaScript : MonoBehaviour {

    float t;
	// Use this for initialization
	void Start () {
        t = Time.time;

	}
	
	// Update is called once per frame
	void Update () {


        if (Time.time- t > 4)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("golpeo", 40f);
        }
        Destroy(gameObject);
    }

}
