using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/******************************************************************************************************
    Marisa Sánchez Falgas
    28-12-17

    Esta clase gestiona los interactuables del tipo "Cajas" y hereda de la clase Interactuables.

*******************************************************************************************************/

    public class Cajas : Interactuable
    {

        public GameObject flechas;          //Para guardar el GameObject que es el icono de recoger flechas.
        public GameObject flechasBlock;     //Para guardar el GameObject que es el icono de no poder recoger flechas.
        public GameObject pociones;         //Para guardar el GameObject que es el icono de recoger pociones.
        public GameObject pocionesBlock;    //Para guardar el GameObject que es el icono de no poder recoger pociones.
        public GameObject vendas;           //Para guardar el GameObject que es el icono de recoger vendas.
        public GameObject vendasBlock;      //Para guardar el GameObject que es el icono de no poder recoger vendas.

        public GameObject caja;             //Para guardar el GameObject que es el icono de la caja.

        public int cantidadFlechas = 1;     //Variable que nos dice la cantidad de flechas que tiene esta objeto.
        public int cantidadPociones = 1;    //Variable que nos dice la cantidad de pociones que tiene esta objeto.
        public int cantidadVendas = 1;      //Variable que nos dice la cantidad de vendas que tiene esta objeto.

        const int CANTIDADMAXIMA_F = 6;     //Variable que nos dice la cantidad máxmima de flechas que podemos tener en el inventario.
        const int CANTIDADMAXIMA_P = 3;     //Variable que nos dice la cantidad máxmima de pociones que podemos tener en el inventario.
        const int CANTIDADMAXIMA_V = 6;    //Variable que nos dice la cantidad máxmima de vendas que podemos tener en el inventario.

        bool cajaAbierta = false;           //Variable para saber si hemos abierto la caja.

        //Animation rotar;
        Animator esteanim;                  //Variable para almacenar el animator que lleva este objeto.

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

            //Desactivamos todos los iconos de los distintos tipos de objetos, tanto de si permite recoger como no.
            flechas.gameObject.SetActive(false);
            flechasBlock.gameObject.SetActive(false);
            pociones.gameObject.SetActive(false);
            pocionesBlock.gameObject.SetActive(false);
            vendas.gameObject.SetActive(false);
            vendasBlock.gameObject.SetActive(false);

            //Desactivamos el iconos de la caja.
            caja.gameObject.SetActive(false);

            //Guardamos el animator de este objeto en la variable declarada al inicio.
            esteanim = gameObject.GetComponent<Animator>();
        }

        //Método que sirve para orientar el canvas de este objeto interactuable para que mire siempre al jugador.
        //Este método será llamado en la función Update()
        public override void OrientarCanvas()
        {
            base.OrientarCanvas();  //Llamamos al mismo método de la clase padre que son las acciones generales de este método.
        }

        //Metodo que sirve para mostrar los iconos de poder o no recoger cada uno de los tipos de objetos que contiene la caja
        //Le pasamos como parámetros la cantidad del objeto a recoger, la cantidad almacenada de este objeto que hay en el inventario,
        //la cantidad máxmima que se puede tener de este objeto, el GameObject del icono de recoger y el GameObject del icono de no poder recoger.
        void ActualizarCanvas(int cantidad, int cantidadAlmacenada, int cantidadMaxima, GameObject obj, GameObject objBlock)
        {
            //Si hay algún objeto que recoger
            if (cantidad > 0)
            {
                //Si tenemos el inventario lleno, mostramos el icono de no poder recoger.
                if (cantidadAlmacenada >= cantidadMaxima)
                {
                    obj.SetActive(false);
                    objBlock.SetActive(true);
                }
                else //Sino, mostramos el icono de poder recoger.
                {
                    obj.SetActive(true);
                    objBlock.SetActive(false);
                }
            }
            else //Sino hay objetos que recoger no mostramos ningún icono.
            {
                obj.SetActive(false);
                objBlock.SetActive(false);
            }
        }


        //Método que será llamado cuando el objeto sea detectado por el trigger que lleva el player para detectar interactuables.
        public override void MostrarCanvas()
        {
            base.MostrarCanvas();   //Llamamos al mismo método de la clase padre que son las acciones generales de este método.

            //A partir de aquí la parte específica de esta clase en cuanto a este método.

            //Si la caja ha sido abierta.
            if (cajaAbierta == true)
            {
                //ocultamos el icnono de la caja
                caja.gameObject.SetActive(false);

                //Creamos una variable y guardamos en ella el inventario.
                Inventario_Manager inventarioManager = GameObject.FindObjectOfType<Inventario_Manager>();

                //Llamamos al método para mostrar los iconos de recoger o no las flechas.
                ActualizarCanvas(cantidadFlechas, inventarioManager.MunicionTotal, CANTIDADMAXIMA_F, flechas, flechasBlock);

                //Llamamos al método para mostrar los iconos de recoger o no las pociones.
                ActualizarCanvas(cantidadPociones, inventarioManager.PocionesTotales, CANTIDADMAXIMA_P, pociones, pocionesBlock);

                //Llamamos al método para mostrar los iconos de recoger o no las vendas.
                ActualizarCanvas(cantidadVendas, inventarioManager.VendajesTotales, CANTIDADMAXIMA_V, vendas, vendasBlock);

            }

            else //si la caja esta cerrada.
            {
                //mostramos el icnono de la caja
                caja.gameObject.SetActive(true);

                //Ocultamos el resto de iconos.
                flechas.gameObject.SetActive(false);
                flechasBlock.gameObject.SetActive(false);
                pociones.gameObject.SetActive(false);
                pocionesBlock.gameObject.SetActive(false);
                vendas.gameObject.SetActive(false);
                vendasBlock.gameObject.SetActive(false);
            }
        }

        //Método que será llamado cuando pulsemos la tecla para interactuar con este objeto.
        public override void Interactuar()
        {
            base.Interactuar();     //Llamamos al mismo método de la clase padre que son las acciones generales de este método.

            //A partir de aquí la parte específica de esta clase en cuanto a este método.

            //Si la caja está abierta
            if (cajaAbierta == true)
            {
                Debug.Log("recojo lo que hay en la caja");

                int cantidadAuxiliar; //Variable auxiliar para guardar el restante si la caja contiene más cantidad de la que podemos llevar de cada item

                //Creamos una variable y guardamos en ella el inventario.
                Inventario_Manager inventarioManager = GameObject.FindObjectOfType<Inventario_Manager>();

                if (inventarioPlayer.municionMaximaAlcanzada() == false)
                {        
                    //La cantidad auxiliar es igual a la cantidad de flechas de la caja menos la cantidad máxima de flechas que podemos llevar
                    cantidadAuxiliar = cantidadFlechas - CANTIDADMAXIMA_F;

                    //Si cantidad auxiliar es negativa, lo ponemos a cero para indicar que no quedan flechas
                    if (cantidadAuxiliar < 0)
                    {
                        cantidadAuxiliar = 0;
                    }

                    //Se añaden las flechas recogidas al inventario del personaje.
                    //Utilizamos un for, porque en la clase que gestiona el inventario, su método obtenerMunicion() solo añade de una en una.
                    //Por tanto hay que llamar al método tantas veces como cantidad de flechas recogemos y que está en nuestra variable cantidad.
                    for (int i = 0; i < cantidadFlechas; i++)
                    {
                        inventarioPlayer.obtenerMunicion(); //llama a la funcion para obtener munición del inventario.
                    }

                    cantidadFlechas = cantidadAuxiliar; //Actualizamos la cantidad de flechas con el restante que queda en la caja.

                    //Llamamos al método para recoger o no las flechas.
                    ActualizarCanvas(cantidadFlechas, inventarioManager.MunicionTotal, CANTIDADMAXIMA_F, flechas, flechasBlock);

                }

                if (inventarioPlayer.pocionesMaximasAlcanzada() == false)
                {
                    //La cantidad auxiliar es igual a la cantidad de pociones de la caja menos la cantidad máxima de pociones que podemos llevar
                    cantidadAuxiliar = cantidadPociones - CANTIDADMAXIMA_P;

                    //Si cantidad auxiliar es negativa, lo ponemos a cero para indicar que no quedan pociones
                    if (cantidadAuxiliar < 0)
                    {
                        cantidadAuxiliar = 0;
                    }

                    //Se añaden las pociones recogidas al inventario del personaje.
                    //Utilizamos un for, porque en la clase que gestiona el inventario, su método obtenerPociones() solo añade de una en una.
                    //Por tanto hay que llamar al método tantas veces como cantidad de pociones recogemos y que está en nuestra variable cantidad.
                    for (int i = 0; i < cantidadPociones; i++)
                    {
                        inventarioPlayer.obtenerPocion(); //llama a la funcion para obtener pociones del inventario.
                    }

                    cantidadPociones = cantidadAuxiliar;    //Actualizamos la cantidad de pociones con el restante que queda en la caja.

                    //Llamamos al método para recoger o no las pociones.
                    ActualizarCanvas(cantidadPociones, inventarioManager.PocionesTotales, CANTIDADMAXIMA_P, pociones, pocionesBlock);
                }

                if (inventarioPlayer.vendasMaximasAlcanzadas() == false)
                {
                    //La cantidad auxiliar es igual a la cantidad de vendas de la caja menos la cantidad máxima de vendas que podemos llevar
                    cantidadAuxiliar = cantidadVendas - CANTIDADMAXIMA_V;

                    //Si cantidad auxiliar es negativa, lo ponemos a cero para indicar que no quedan vendas
                    if (cantidadAuxiliar < 0)
                    {
                        cantidadAuxiliar = 0;
                    }

                    //Se añaden las vendas recogidas al inventario del personaje.
                    //Utilizamos un for, porque en la clase que gestiona el inventario, su método obtenerVendas() solo añade de una en una.
                    //Por tanto hay que llamar al método tantas veces como cantidad de vendas recogemos y que está en nuestra variable cantidad.
                    for (int i = 0; i < cantidadVendas; i++)
                    {
                        inventarioPlayer.obtenerVendaje(); //llama a la funcion para obtener vendas del inventario.	
                    }

                    cantidadVendas = cantidadAuxiliar;  //Actualizamos la cantidad de vendas con el restante que queda en la caja.
                                                        //Llamamos al método para recoger o no las vendas.
                    ActualizarCanvas(cantidadVendas, inventarioManager.VendajesTotales, CANTIDADMAXIMA_V, vendas, vendasBlock);
                }
            }

            else //Si la caja está cerrada, la abrimos y llamamosa una corrutina que muestra los iconos del contenido un poco más tarde.
            {
                Debug.Log("abro la caja");
                cajaAbierta = true;
                esteanim.SetTrigger("abrir");
                StartCoroutine(CajaAbierta());
            }

        }

        //Corrutina que espera unos segundos antes de mostrar los iconos.
        IEnumerator CajaAbierta()
        {
            yield return new WaitForSeconds(2f);
            MostrarCanvas();
        }

        //Método que será llamado cuando el objeto salga del trigger que lleva el player para detectar interactuables.
        public override void OcultarCanvas()
        {
            base.OcultarCanvas();   //Llamamos al mismo método de la clase padre que son las acciones generales de este método.
        }

    }

