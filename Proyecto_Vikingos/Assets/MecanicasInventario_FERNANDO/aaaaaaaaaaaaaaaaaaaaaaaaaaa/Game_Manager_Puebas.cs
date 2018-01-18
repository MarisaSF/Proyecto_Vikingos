using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager_Puebas : MonoBehaviour {


    public GameObject Inventario;
    public GameObject gUIpayo;
    public bool modoInventario= false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(Time.timeScale != 0 && !Inventario.activeInHierarchy && gUIpayo.activeInHierarchy)
            {
                Time.timeScale = 0;
                gUIpayo.SetActive(false);
                Inventario.SetActive(true);
               
            }
            else
            {
                Time.timeScale = 1;
                gUIpayo.SetActive(true);
                Inventario.SetActive(false);
                
            }

            //if (Time.timeScale == 0 && Inventario.activeInHierarchy && !gUIpayo.activeInHierarchy && modoInventario)
            //{
            //    Time.timeScale = 1;
            //    gUIpayo.SetActive(true);
            //    Inventario.SetActive(false);
            //    modoInventario = false;
            //}
        }
	}
}
