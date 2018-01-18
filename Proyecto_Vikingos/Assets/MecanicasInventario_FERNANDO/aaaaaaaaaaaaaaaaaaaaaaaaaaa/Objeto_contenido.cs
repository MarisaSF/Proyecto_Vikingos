using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class Objeto_contenido : MonoBehaviour {

    /****************************************************************
   Este script gestiona el panel descripcion y detecta que item se encuentra en cada slot del panel de armaduras, sets y jugador.

   David Lozano Ronda

   8/01/2018
   ****************************************************************/

    public string nombreEquipoActual ;
    public GameObject paneldescripcion;
    GameObject definicion;
    public Vector2 posicion;

    public void Start()
    {
       
       
    }
    public void Update()
    {
       
    }
    public void LeerNombreImagen()
    {
       


            //esto pasa al scritp accede a inventario manager a su metodo equipar_equipamiento y le pasa como parametro el nombre de la imagen(que representa a cada pieza de equipamiento).
            transform.parent.parent.parent.parent.GetComponent<Inventario_Manager>().equipar_equipamiento(transform.GetChild(0).GetComponent<Image>().sprite.name);
            Debug.Log(transform.GetChild(0).GetComponent<Image>().sprite.name);
            // Debug.Log(transform.childCount);
            // Debug.Log(transform.GetChild(0).name);

            //esto pone el exto con la E verde on cuando es equipado
            transform.GetChild(0).GetChild(0).gameObject.SetActive(true);
        
        

    }

    //pointer ENTER
    public void descripcionEnPanel()
    {

        nombreEquipoActual = transform.GetChild(0).GetComponent<Image>().sprite.name;
        definicion =  Instantiate(paneldescripcion, this.transform);
        Debug.Log(definicion.transform.parent.name);
        // definicion.transform.SetParent(this.transform);
        // GameObject.Find("Canvas").GetComponent<Transform>()
        // Debug.Log(definicion.name);
        Debug.Log(nombreEquipoActual);
        foreach (var posicionesLista in Base_De_Datos.miInventario)
        {
            foreach (var posicionArray in posicionesLista)
            {
                if (posicionArray.icono.name == nombreEquipoActual)
                {
                   
                  
                    //Le da el nombre
                    definicion.transform.Find("Nombre").GetComponent<Text>().text = posicionArray.nombre;


                    definicion.transform.Find("Icono").GetComponent<Image>().sprite = posicionArray.icono;

                    definicion.transform.Find("Fuerza").GetComponent<Text>().text = "Fuerza: " + posicionArray.ataque;

                    definicion.transform.Find("Defensa").GetComponent<Text>().text = "Defensa: " + posicionArray.defensa;
                    // paneldescripcion.transform.position = transform.position;

                    //null reference con el panel, hay que encontrarlo


                }
            }
        }

    }

    public void dejarDeLeerDescripcion()
    {

        Debug.Log("has dejado de leer la descripcion de la pieza");
        Debug.Log(definicion.name);
        Destroy(definicion.gameObject);

    }

}
