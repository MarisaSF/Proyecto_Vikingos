using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******************************************************************************************************
    Marisa Sánchez Falgas
    06/01/18.

    Esta clase contiene los métodos generales de los objetos interactuables y gestiona los iconos que
    muestra.

*******************************************************************************************************/

    public class Interactuable : MonoBehaviour
    {
        public Transform canvas;                                        //Para guardar el Transform del canvas que lleva el objeto interactuable.
        [HideInInspector] public Transform player;                      //Para guardar el Transform del jugador.
        [HideInInspector] public Inventario_Player inventarioPlayer;    //Para guardar la clase que gestiona el inventario que hay en la escena.

        //Método para inicializar las variables que se llamara desde la función Start()
        public virtual void Iniciar()
        {
            inventarioPlayer = GameObject.FindObjectOfType<Inventario_Player>();    //Recojemos el script del inventario que hay en la escena.
            player = GameObject.FindGameObjectWithTag("Player").transform;          //Buscamosel GameObject que se llama "PLAYER" y lo gurdamos en nuestra variable.
            canvas.gameObject.SetActive(false);                                     //Desactivamos el canvas de este objeto interactuable.
        }

        //Método que sirve para orientar el canvas de este objeto interactuable para que mire siempre al jugador.
        //Este método será llamado en la función Update()
        public virtual void OrientarCanvas()
        {
            //Vector que guarda la posicion del jugador, pero la altura del canvas de este objeto interactuable para que no mire arriba o abajo.
            Vector3 canvasPos = new Vector3(player.position.x, canvas.position.y, player.position.z);

            canvas.LookAt(canvasPos); //Hace que mire en la dirección que hemos calculado arriba.
        }

        //Método que será llamado cuando pulsemos la tecla para interactuar con este objeto.
        public virtual void Interactuar()
        {
            Debug.Log("Interactuo");
        }

        //Método que será llamado cuando el objeto sea detectado por el trigger que lleva el player para detectar interactuables.
        public virtual void MostrarCanvas()
        {
            Debug.Log("Muestro los iconos");
            canvas.gameObject.SetActive(true);      //Mostramos el canvas de este objeto.
        }

        //Método que será llamado cuando el objeto salga del trigger que lleva el player para detectar interactuables.
        public virtual void OcultarCanvas()
        {
            Debug.Log("Oculto los iconos");
            canvas.gameObject.SetActive(false);     //Ocultamos el canvas de este objeto.
        }

    }
