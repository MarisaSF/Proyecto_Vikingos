using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desmontar : MonoBehaviour {
    Rigidbody[] tralari;
    bool una;
	// Use this for initialization
	void Start () {
        tralari = GetComponentsInChildren<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (una == false)
        {
            foreach (Rigidbody rigi in tralari)
            {

                rigi.isKinematic = false;
                rigi.AddForce(transform.right * -4, ForceMode.Impulse);
            }
            una = true;
        }
	}
}
