using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/******************************************************************************************************
    Marisa Sánchez Falgas
    04/01/18

    Esta clase gestiona las zonas de detección para activar las diferentes partes del tutorial

*******************************************************************************************************/

namespace MarisaInterfaz    //nombre que contiene los scripts de tutorial
{
    public class CanvasTutorial : MonoBehaviour
    {

        public Image fondo;         //Para guardar el fondo del tutorial.
        public Button boton;        //Para guardar el botón de continuar del tutorial.
        public Text explicacion;    //Para guardar el texto explicativo del tutorial.

        public Text textoBoton;     //Para guardar el texto del botón de continuar del tutorial.
        public Image imagenBoton;   //Para guardar la imagen del botón de continuar del tutorial.

        //Almacena los mensajes de las distíntas partes del tutorial.
        public string[] mensajesTutorial = new string[]

        {

        "Bienvenido viajero. Acabas de llegar a la Isla, a lo largo de tu recorrido deberás enfrentarte a numerosos obstaculos." + "\n"

        + "Para desplazarte usa las teclas de control W, A, S, y D.",

        "Puedes cruzar distancias o superar obstaculos realizando un salto." + "\n"

        + "Para saltar pulsa la tecla ESPACIO.",
                
        "Puedes ocultarte tras coberturas pulsando C",

        "Acabas de econtrar un objeto. A lo largo de tu camino encontrars numerosos itéms a los que dar uso, como Flechas, Pociones, Vendajes y Oro." + "\n"

        + "Pero ten en cuenta viajero que estos objetos son limitados. Debes ser cauto a la hora de darles un uso o podrás encontrarte en con serias dificultades." + "\n" +

        "También debes tener en cuenta como usar estos objetos, ya que en combate, solo podras usar los vendajes para sanarte.",

        "Para atacar pulsa click derecho del ratón"  + "\n" +

        "Para disparar con el arco pulsa click izquierdo del ratón, cuanto mas tiempo mantengas pulsado mas daño hasrás"

        };

        public static CanvasTutorial instance = null;              //Instancia estática de esta clase para no tener más de una al mismo tiempo y hacer un singleton.

        //Esto se llama antes que cualquier otra funcion al inicio
        void Awake()
        {
            //Comprobamos si existe la instancia de esta clase en la escena
            if (instance == null)

                //si no existe establecemos la instancia a esta
                instance = this;

            //Si la instancia existe y no es esta
            else if (instance != this)

                //Destruye este objeto ya que solo puede haber una instancia en escena.
                Destroy(gameObject);

            //Hace que no se destruya cuando se carga otra escena.
            DontDestroyOnLoad(gameObject);
        }

        // Esto se llama cuando empieza el script después de Awake()
        void Start()
        {
            MostrarOcultarCanvas(false);    //Ocultamos el canvas
        }

        //Método que sirve para ocultar o mostrar los elementos del canvas del tutorial.
        //Le pasamos un parámetro b que dice si mostramos u ocultamos
        public void MostrarOcultarCanvas(bool b)
        {
            fondo.enabled = b;
            boton.enabled = b;
            explicacion.enabled = b;
            imagenBoton.enabled = b;
            textoBoton.enabled = b;

            if (b == true)
            {
                Time.timeScale = 0;
            }

            else
            {
                Time.timeScale = 1;
            }
        }

        //Método que sirve para actualizar el texto del tutorial a la sección correspondiente.
        //Le pasamos un parámetro que será ña sección a mostrar.
        public void ActualizarTextos(int parteTutorial)
        {
            explicacion.text = mensajesTutorial[parteTutorial]; //Le asignamos al texto, el mensaje corrspondiente de la variable que contiene las partes del tutorial según el indice que le pasamos.
        }

        //Metodo que sirve para activar las mecánicas del turotorial.
        public void ActivarMecanica(int mecanica)
        {
            switch(mecanica)
            {
                case 0:
                    //Accedemos el script y ponemos a true la variable para usar el arco.
                    GameObject.FindObjectOfType<CharaController>().RMBBlock = false;

                    //Accedemos el script y ponemos a true la variable para usar el hacha.
                    GameObject.FindObjectOfType<CharaController>().LMBBlock = false;

                    break;
                case 1:
                    //Accedemos el script y ponemos a true la variable para usar el hacha.
                    GameObject.FindObjectOfType<CharaController>().LMBBlock = false;
                    break;
                case 2:
                    //Accedemos el script y ponemos a true la variable para usar el slato.
                    GameObject.FindObjectOfType<CharaController>().btnEspacioBlock = false;
                    break;
                case 3:
                    //Accedemos el script y ponemos a true la variable para usar el agacharse.
                    GameObject.FindObjectOfType<CharaController>().btnCBlock = false;
                    break;
                case 4:
                    
                   
                    break;
            }
        }

    }
}
