using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******************************************************************************************************
    Marisa Sánchez Falgas
    04/01/18

    Esta clase gestiona las zonas de detección para activar las diferentes partes del tutorial

*******************************************************************************************************/

namespace MarisaInterfaz    //nombre que contiene los scripts de tutorial
{
    public class Tutorial : MonoBehaviour
    {
        //Para saber si este trigger activa una mecánica.
        public bool activarMecanica = false;

        //Mecánica que se activará.
        public int mecanicaActivar = 0;

        public int parteTutorial = 0;      //Para saber que parte del tutorial activa este triger


        //Si algo entra dentro del trigger
        private void OnTriggerEnter(Collider other)
        {
            //Si tiene el tag del jugador
            if (other.tag == "Player")
            {
                //Creamos una variable para recoger el CanvasTutorial del objeto que se llama "CanvasTutorial"
                CanvasTutorial tutorial = GameObject.Find("CanvasTutorial").GetComponent<CanvasTutorial>();

                //Si el tutorial a mostrar no está fuera del número establecido de secciones de tutorial.
                if (parteTutorial < tutorial.mensajesTutorial.Length)
                {
                    tutorial.ActualizarTextos(parteTutorial);   //Actualizamos el texto a mostrar del tutorial con el correspondiente a esta seccion.

                    tutorial.MostrarOcultarCanvas(true);        //Mostramos el canvas del tutorial.

                    //Si la variable es true puedo activar una mecánica.
                    if (activarMecanica == true)
                    {
                        //Llamamos al metodo para activar la mecánica.
                        tutorial.ActivarMecanica(mecanicaActivar);
                    }

                    Destroy(gameObject);                        //Destruimos el triger para no disparar el tutorial una segunda o más veces.

                }
            }
        }
    }
}
