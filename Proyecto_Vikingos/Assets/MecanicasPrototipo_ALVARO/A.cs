using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour {

    public Transform b;
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("entrando");

            other.transform.position = b.position;
        }

    }
}
