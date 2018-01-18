using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abrir_puerta : MonoBehaviour {

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            GameObject puerta = GameObject.FindGameObjectWithTag("puerta");
            Destroy(puerta);
            Destroy(this.gameObject);
        }
    
    }

}
