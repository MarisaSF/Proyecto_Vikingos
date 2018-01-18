using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class escaleras : MonoBehaviour {

    public Transform inicio;
    public Transform final;

	// Use this for initialization
	void Start () {
		
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("toca la escalera");
            collision.gameObject.transform.position = final.position;
        }
        
        
    }
}
