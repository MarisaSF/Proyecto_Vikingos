using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******************************************************************************************************
    Marisa Sánchez Falgas
    28-12-17

    Esta clase gestiona la deteccion por parte del jugador de los objetos interactuables.

*******************************************************************************************************/

    public class Detector : MonoBehaviour
    {

        bool puedoRecoger = false;      //Para saber si podemos recoger el objeto al pulsar el control correspondiente.

        // Esto se ejecuta cada fotograma
        void Update()
        {
            //Si pulso la tecla de recoger activo el booleano
            if (Input.GetKeyDown(KeyCode.E))
            {
                puedoRecoger = true;
            }

            //Si suelto la tecla de recoger desactivo el booleano
            else if (Input.GetKeyUp(KeyCode.E))
            {
                puedoRecoger = false;
            }
        }

        //Si algo entra dentro del trigger
        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.name);
            //si es un objeto con el tag interactuable, llamamos a su método de MostrarCanvas()
            if (other.tag == "INTERACTUABLE")
            {
                other.gameObject.SendMessage("MostrarCanvas");
            }
        }

        //Si algo sale del trigger
        private void OnTriggerExit(Collider other)
        {
            //si es un objeto con el tag interactuable, llamamos a su método de OcultarCanvas()
            if (other.tag == "INTERACTUABLE")
            {
                other.gameObject.SendMessage("OcultarCanvas");
            }
        }

        //Si algo está dentro del trigger
        private void OnTriggerStay(Collider other)
        {
            //Si habia pulsado la tecla de recoger
            if (puedoRecoger == true)
            {
                //si es un objeto con el tag interactuable, llamamos a su método de Interactuar()
                if (other.tag == "INTERACTUABLE")
                {
                    other.gameObject.SendMessage("Interactuar");
                    puedoRecoger = false;
                }
            }
        }
    }
