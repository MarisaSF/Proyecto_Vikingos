using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CAJAS : MonoBehaviour
{

    public GameObject text;
   
    public bool etadentro;
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("entrando");
            etadentro = true;
            text.SetActive(true);
            
           
        }

   
    }

        void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            Debug.Log("entrando");
            etadentro = false;
            text.SetActive(false);
           
        }

    }
        void Update()
        {
            if (etadentro)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    text.SetActive(false);
                    Destroy(gameObject);
                   
                }
            }

        }
    
}
