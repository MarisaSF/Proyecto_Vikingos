using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

/******************************************************************************************************
    Marisa Sánchez Falgas
    05/01/18

    Esta clase gestiona el menú de opciones del juego.

*******************************************************************************************************/
namespace MarisaInterfaz
{
    public class MenuManager : MonoBehaviour
    {
        bool muestroMenu;                   //Para saber si el menú es visible o no.
        public GameObject menu;             //Para guardar el objeto que contiene todo los objetos del menu que hay en la escena
            
        int width;                          //Para Guardar la anchura de la pantalla.
        int height;                         //Para Guardar la altura de la pantalla.
        bool fullScreen;                    //Para saber si está activada la pantalla completa.
        int refreshRate;                    //Para guardar el ratio de refresco de la pantalla.
        
        //Variables para guardar los textos de las opciones del menu de juego.
        public Text textoPantalla;          
        public Text textoResolucion;
        public Text textoCalidad;
        public Text textoAntialiasing;
        public Text textoSombras;
        public Text textoVolumen;

        //Variables que guardan o indican cada una de las opcciones seleccionadas
        int indiceRatioResolucion = 0;
        int indiceCalidad = 0;
        int indiceAntialiasing = 0;
        int indiceSombras = 0;
        int indiceVolumen = 0;

        public AudioMixer masterMixer;      //Para guardar el master mixer de sonido de la escena.

        //variables de array de tipo int que contienen los posibles valores de las distintas opciones del menú.
        int[] ratiosDeRefresco = new int[] { 50, 60, 120, 240 };
                
        int[] resolucionWidth = new int[] { 1920, 1024, 850, 800 };

        int[] resolucionHeight = new int[] { 1080, 768, 480, 600 };

        public static MenuManager instance = null;             //Instancia estática de esta clase para no tener más de una al mismo tiempo y hacer un singleton.

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

        //Se llama al inicio
        void Start()
        {
            Inicializar();      //Llama al método de esta clase que inicializa este script.
        }

        //Se llama cada fotograma
        void Update()
        {
            //Si pulsamos la tecla escape mostramos u ocultamos el menú.
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OcultarMostrarMenu();    
            }
        }

        //Método que sirve para ocultar o mostrar el menú de juego.
        public void OcultarMostrarMenu()
        {
            muestroMenu = !muestroMenu;     //muestro menú es igual a lo contrario de lo que vale
            menu.SetActive(muestroMenu);    //Activamos o desactivamos segun muestro menú.         
        }

        //Método para inicializar las variables que se llamara desde la función Start()
        public void Inicializar()
        {
            //Se establecen los valores que se mostrarán pordefecto al iniciar.
            indiceRatioResolucion = 0;
            indiceCalidad = QualitySettings.names.Length - 1;
            indiceAntialiasing = 1;
            indiceSombras = 2;
            indiceVolumen = 12;

            width = resolucionWidth[indiceRatioResolucion];
            height = resolucionHeight[indiceRatioResolucion];
            fullScreen = true;
            refreshRate = ratiosDeRefresco[1];

            Screen.SetResolution(width, height, fullScreen, refreshRate);
            ChangeQuality(QualitySettings.names.Length - 1);
            Antialiasing(1);
            Shadows(2);
            ChangeVolume(12);

            textoPantalla.text = "Habilitado";
            textoResolucion.text = resolucionWidth[indiceRatioResolucion].ToString() + "x" + resolucionHeight[indiceRatioResolucion].ToString();
            textoCalidad.text = QualitySettings.names[indiceCalidad].ToString();
            textoAntialiasing.text = "2x";
            textoSombras.text= "Alta";
            textoVolumen.text = indiceVolumen.ToString();

            //Desactivamos/ocultamos el menú.
            muestroMenu = false;
            menu.SetActive(false);
        }

        //Método que sirve para cambiar la resolucion de la pantalla.
        public void Resolution(int _resolution)
        {
            //Si el valor que hemos establecido es menor que el valor de resoluciones posible.
            if (_resolution < resolucionWidth.Length)
            {
                //Establecemos la resolución de alto y ancho de pantalla.
                width = resolucionWidth[_resolution];
                height = resolucionHeight[_resolution];
                Screen.SetResolution(width, height, fullScreen, refreshRate);
            }
        }

        //Método que sirve para cambiar la calidad gráfica de la aplicación.
        public void ChangeQuality(int _qualityLevel)
        {
            //Si el valor que hemos establecido es menor que el valor de calidades posibles.
            if (_qualityLevel < QualitySettings.names.Length)
            {
                //Establecemos la calidad.
                QualitySettings.SetQualityLevel(_qualityLevel, true);
            }

        }

        //Método que sirve para cambiar el nivel de antialiasing de la aplicación.
        public void Antialiasing(int _level)
        {
            //Si el valor que hemos establecido es menor que el de los valores posibles.
            if (_level < 4)
            {
                //Establecemos el nivel del antialiasing.
                QualitySettings.antiAliasing = _level;
            }
        }

        //Método que sirve para cambiar la calidad de las sombras de la aplicación.
        public void Shadows(int _level)
        {
            //Si el valor que hemos establecido es menor que el de los valores posibles.
            if (_level < 3)
            {
                //Establecemos la calidad de las sombras dependiendo del valor seleccionado.
                switch (_level)
                {
                    case 0:
                        QualitySettings.shadows = ShadowQuality.Disable;
                        break;
                    case 1:
                        QualitySettings.shadows = ShadowQuality.HardOnly;
                        break;
                    case 2:
                        QualitySettings.shadows = ShadowQuality.All;
                        break;
                }
            }
        }

        //Método que sirve para cambiar el nivel del volumen de juego.
        public void ChangeVolume(int _level)
        {
            masterMixer.SetFloat("MasterVolume", _level);
        }

        //Método que sirve para seleccionar el modo pantalla completa o modo ventana cuando pulsamos los botones de la interfaz.
        public void CambiarValorPantallaCompleta(bool direccion)
        {
            //es igual a lo contrario de lo que vale (si esta en true vale false).
            fullScreen = !fullScreen;

            //establecemos la resolucion de pantalla.
            Screen.SetResolution(width, height, fullScreen, refreshRate);

            //Actualizamos el texto del menú.
            if (fullScreen == true)
            {
                textoPantalla.text = "Habilitado";
            }
            else
            {
                textoPantalla.text = "Deshabilitado";
            }
        }

        //Método que sirve para cambiar la resolución cuando pulsamos los botones de la interfaz.
        public void CambiarValoResolucion(bool direccion)
        {
            //según pulsamos el botón izquierda o derecha, establecemos el índice.
            if (direccion == true)
            {
                //si pulsamos el botón derecho, sumamos 1 al índice.
                indiceRatioResolucion++;

                //y si el índice se sale del rango de posibles valores lo ponemos a 0
                if (indiceRatioResolucion >= resolucionHeight.Length)  
                {
                    indiceRatioResolucion = 0;
                }
            }
            else
            {
                //Si pulsamos el botón izquierdo restamos 1 al índice.
                indiceRatioResolucion--;
                //Y si el indice es menor que 0, será el máximo de rango de valores
                if (indiceRatioResolucion < 0)
                {
                    indiceRatioResolucion = resolucionHeight.Length - 1;
                }
            }

            //Según el índice establecemos la resolución.
            width = indiceRatioResolucion;
            height = indiceRatioResolucion;

            Screen.SetResolution(width, height, fullScreen, refreshRate);

            //Actualizamos el texto del menú recogiendo el valor de ancho y largo segun el índice que hemos obtenido..
            textoResolucion.text = resolucionWidth[indiceRatioResolucion].ToString() + "x" + resolucionHeight[indiceRatioResolucion].ToString();
        }

        //Método que sirve para cambiar el volumen cuando pulsamos los botones de la interfaz.
        public void CambiarVolumen(bool direccion)
        {
            if (direccion == true)
            {
                indiceVolumen++;

                if (indiceVolumen > 20)
                {
                    indiceVolumen = 0;
                }
            }
            else
            {
                indiceVolumen--;

                if (indiceVolumen < 0)
                {
                    indiceVolumen = 20;
                }
            }

            //llamamos a la función que cambia el volumen del audio mixer
            ChangeVolume(indiceVolumen);
            //Actualizamos el texto de la opcion volumen.
            textoVolumen.text = indiceVolumen.ToString();
        }

        //Método que sirve para cambiar la calidad gráfica cuando pulsamos los botones de la interfaz.
        public void CambiarCalidad(bool direccion)
        {
            if (direccion == true)
            {
                indiceCalidad++;

                if (indiceCalidad >= QualitySettings.names.Length)
                {
                    indiceCalidad = 0;
                }
            }
            else
            {
                indiceCalidad--;

                if (indiceCalidad < 0)
                {
                    indiceCalidad = QualitySettings.names.Length - 1;
                }
            }

            ChangeQuality(indiceCalidad);
            //Actualizamos el texto de la opcion calidad.
            textoCalidad.text = QualitySettings.names[indiceCalidad].ToString();
         }

        //Método que sirve para cambiar el nivel de antialiasing cuando pulsamos los botones de la interfaz.
        public void CambiarAntialiasing(bool direccion)
        {
            if (direccion == true)
            {
                indiceAntialiasing++;

                if (indiceAntialiasing >= 4)
                {
                    indiceAntialiasing = 0;
                }
            }
            else
            {
                indiceAntialiasing--;

                if (indiceAntialiasing < 0)
                {
                    indiceAntialiasing = 3;
                }
            }

            Antialiasing(indiceAntialiasing);
            //Actualizamos el texto de la opcion antialiasing dependiendo del valor seleccionado.
            switch (indiceAntialiasing)
            {
                case 0:
                    textoAntialiasing.text = "Off";
                    break;
                case 1:
                    textoAntialiasing.text = "2x";
                    break;
                case 2:
                    textoAntialiasing.text = "4x";
                    break;
                case 3:
                    textoAntialiasing.text = "8x";
                    break;
            }
        }

        //Método que sirve para cambiar la calidad de las sombras cuando pulsamos los botones de la interfaz.
        public void CalidadSombras(bool direccion)
        {
            if (direccion == true)
            {
                indiceSombras++;

                if (indiceSombras >= 3)
                {
                    indiceSombras = 0;
                }
            }
            else
            {
                indiceSombras--;

                if (indiceSombras < 0)
                {
                    indiceSombras = 2;
                }
            }

            Shadows(indiceSombras);
            //Actualizamos el texto de la opcion calidad de sombras dependiendo del valor seleccionado.
            switch (indiceSombras)
            {
                case 0:
                    textoSombras.text = "Off";
                    break;
                case 1:
                    textoSombras.text = "Media";
                    break;
                case 2:
                    textoSombras.text = "Alta";
                    break;             
            }
        }
    }   

}
