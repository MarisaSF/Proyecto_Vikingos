using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******************************************************************************************************
    Marisa Sánchez Falgas
    04/01/18.

    Esta clase gestiona los interactuables del tipo "Venda" y hereda de la clase Interactuables.

*******************************************************************************************************/

    public class Venda : Interactuable
    {

        public GameObject venda;      //Para guardar el GameObject que es el icono de recoger vendas.
        public GameObject vendaBlock; //Para guardar el GameObject que es el icono de no poder recoger vendas.

        public int cantidad;        //Variable que nos dice la cantidad de vendas que tiene esta objeto.
                                    //De momento se plantea que este objeto siempre tenga 1 de cantidad.
                                    //Aunque se declara así por si en un futuro se plantea que tenga mas de uno.

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


            //A partir de aquí la parte específica de esta clase en cuanto a este método.

            //Si ya tenemos el máximo de vendas en el inventario mostramos el icono de bloqueo.
            if (GameObject.FindObjectOfType<Inventario_Manager>().VendajesTotales >= 6)
            {
                venda.SetActive(false);
                vendaBlock.SetActive(true);
            }
            else //Sino, mostramos el icono de recoger.
            {
                venda.SetActive(true);
                vendaBlock.SetActive(false);
            }
        }

        //Método que será llamado cuando pulsemos la tecla para interactuar con este objeto.
        public override void Interactuar()
        {
            base.Interactuar();     //Llamamos al mismo método de la clase padre que son las acciones generales de este método.

            //A partir de aquí la parte específica de esta clase en cuanto a este método.
            Debug.Log("añade venda al inventario");

            //Se añaden las vendas recogidas al inventario del personaje.
            //Utilizamos un for, porque en la clase que gestiona el inventario, su método obtenerVendaje() solo añade de una en una.
            //Por tanto hay que llamar al método tantas veces como cantidad de vendas recogemos y que está en nuestra variable cantidad.
            //De momento se plantea que este objeto siempre tenga 1 de cantidad.

            if (inventarioPlayer.vendasMaximasAlcanzadas() == false)
            {
                for (int i = 0; i < cantidad; i++)
                {
                    inventarioPlayer.obtenerVendaje(); //llama a la funcion para obtener vendas del inventario.
                }

                canvas.gameObject.SetActive(false);     //Desactivamos el canvas de este objeto.

                Destroy(gameObject);    //Destruimos este objeto.
            }


        }

        //Método que será llamado cuando el objeto salga del trigger que lleva el player para detectar interactuables.
        public override void OcultarCanvas()
        {
            base.OcultarCanvas();   //Llamamos al mismo método de la clase padre que son las acciones generales de este método.
        }
    }