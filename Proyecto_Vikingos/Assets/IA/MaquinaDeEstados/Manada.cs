using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manada : MonoBehaviour {

    public GameObject[]manada;
  public  bool manadaActiva;
	// Use this for initialization
	void Start () {

       
	}

    // Update is called once per frame
    void Update()
    {
        if (manadaActiva == false)
        {
            for (int i = 0; i < manada.Length; i++)
            {
                if (manada[i].GetComponent<EnemyManager>().modoataque == true)
                {
                    foreach (GameObject man in manada)
                    {
                        man.GetComponent<Animator>().SetTrigger("run1");

                    }
                    manadaActiva = true;
                    break;
                }
                else
                {
                    manadaActiva = false;
                }
            }
        }
    }
}
