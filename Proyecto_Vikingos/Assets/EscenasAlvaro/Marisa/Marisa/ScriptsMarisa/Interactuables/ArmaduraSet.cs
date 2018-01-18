using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******************************************************************************************************
    Marisa Sánchez Falgas
    11/01/18.

    Esta clase gestiona los interactuables del tipo "Oro" y hereda de la clase Interactuables.

*******************************************************************************************************/

    public class ArmaduraSet : Interactuable
    {

        public int parteArmadura;        //Variable que nos dice la pieza dela armadura que tiene esta objeto.
        public int set;                  // Variable que nos dice a que set pertence este objeto.          

        // Se llama al inicio
        void Start()
        {
            Iniciar();  //Llama al método de esta clase que inicializa este script.
        }

        // Se llama cada fotograma
        void Update()
        {
            OrientarCanvas();   //Llama al método de esta clase que orienta el canvas de este objeto.
        }

        //Método para inicializar las variables que se llamara desde la función Start()
        public override void Iniciar()
        {
            base.Iniciar();     //Hacemos la inicalización del mismo método de la clase padre que son las acciones generales de este método.
        }

        //Método que sirve para orientar el canvas de este objeto interactuable para que mire siempre al jugador.
        //Este método será llamado en la función Update()
        public override void OrientarCanvas()
        {
            base.OrientarCanvas();  //Llamamos al mismo método de la clase padre que son las acciones generales de este método.
        }

        //Método que será llamado cuando el objeto sea detectado por el trigger que lleva el player para detectar interactuables.
        public override void MostrarCanvas()
        {
            base.MostrarCanvas();   //Llamamos al mismo método de la clase padre que son las acciones generales de este método.
        }

        //Método que será llamado cuando pulsemos la tecla para interactuar con este objeto.
        public override void Interactuar()
        {
            base.Interactuar();     //Llamamos al mismo método de la clase padre que son las acciones generales de este método.

            //A partir de aquí la parte específica de esta clase en cuanto a este método.
            Debug.Log("añade una pieza de armadura al inventario");

            inventarioPlayer.obtenerEquipo(set, parteArmadura);
           
            canvas.gameObject.SetActive(false);     //Desactivamos el canvas de este objeto.

            Destroy(gameObject);                    //Destruimos este objeto.


        }

        //Método que será llamado cuando el objeto salga del trigger que lleva el player para detectar interactuables.
        public override void OcultarCanvas()
        {
            base.OcultarCanvas();   //Llamamos al mismo método de la clase padre que son las acciones generales de este método.
        }
    }
