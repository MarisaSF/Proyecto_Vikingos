using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class matarPorContacto : MonoBehaviour {

           public GameObject[] enemigos;

           void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("entrando");
            for (int i = 0; i < enemigos.Length; i++)
            {
                Destroy(enemigos[i]);
            }
        }

    }

}
