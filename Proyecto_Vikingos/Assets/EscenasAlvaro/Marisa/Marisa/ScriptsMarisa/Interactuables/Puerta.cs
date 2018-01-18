using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/******************************************************************************************************
    Marisa Sánchez Falgas
     3/01/18.

    Esta clase gestiona los interactuables del tipo "Puerta" y hereda de la clase Interactuables.

*******************************************************************************************************/

    public class Puerta : Interactuable
    {

        public Text puertaText;             //Para guardar el Texto que tiene la puerta.

        public bool tieneLlave = false;     //Para saber si tenemos la llave que abre esta puerta.

        Animator esteanim;                  //Variable para almacenar el animator que lleva este objeto.

        // Se llama al inicio
        void Start()
        {
            Iniciar();  //Llama al método de esta clase que inicializa este script.
        }

        //Método para inicializar las variables que se llamara desde la función Start()
        public override void Iniciar()
        {
            base.Iniciar();     //Hacemos la inicalización del mismo método de la clase padre que son las acciones generales de este método.

            //A partir de aquí la parte específica de esta clase en cuanto a este método.

            //Guardamos el animator de este objeto en la variable declarada al inicio.
            esteanim = gameObject.GetComponent<Animator>();
        }


        //Método que será llamado cuando el objeto sea detectado por el trigger que lleva el player para detectar interactuables.
        public override void MostrarCanvas()
        {
            base.MostrarCanvas();   //Llamamos al mismo método de la clase padre que son las acciones generales de este método.

            //A partir de aquí la parte específica de esta clase en cuanto a este método.

            //Sino tenemos la llave mostramos que esta cerrada
            if (tieneLlave == false)
            {
                puertaText.text = "Cerrado.";
            }
            else //si tenemos la llave mostramos la tecla para abrir la puerta 
            {
                puertaText.text = "Pulsa E para abrir.";

            }
        }

        //Método que será llamado cuando pulsemos la tecla para interactuar con este objeto.
        public override void Interactuar()
        {
            base.Interactuar();     //Llamamos al mismo método de la clase padre que son las acciones generales de este método.

            //A partir de aquí la parte específica de esta clase en cuanto a este método.

            //Si tenemos la llave abrimos la puerta y ocultamos el canvas.
            if (tieneLlave == true)
            {
                esteanim.SetTrigger("abrir");
                OcultarCanvas();
            }

        }

        //Método que será llamado cuando el objeto salga del trigger que lleva el player para detectar interactuables.
        public override void OcultarCanvas()
        {
            base.OcultarCanvas();   //Llamamos al mismo método de la clase padre que son las acciones generales de este método.
        }
    }
