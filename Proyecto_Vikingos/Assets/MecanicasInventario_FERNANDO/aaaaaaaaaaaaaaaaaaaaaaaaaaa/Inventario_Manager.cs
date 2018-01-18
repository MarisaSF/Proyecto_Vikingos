using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario_Manager : MonoBehaviour {

   /****************************************************************
   Este script gestiona el panel de sets, el panel del jugador, el panel de armaduras, la municion del jugador   , los elementos curativos.

   David Lozano Ronda

   8/01/2018
   ****************************************************************/

    

    //botones de accion

    public Button botonSets; //OK

    public Button botonArmaduras; //OK

    public Button botonSalir;  //OK

    public Button botonCasco; //OK
    public Button botonPechera;
    public Button botonPantalon;
    public Button botonBotas;

    //paneles de info
    public GameObject panel_sets;
    public GameObject panel_armaduras;

    public GameObject subpanel_cascos;
    public GameObject subpanel_Pecheras;
    public GameObject subpanel_Pantalone;
    public GameObject subpanel_Botas;

    //*

    // GUI pociones, municion, vendas
    //public List<Pocion> pociones = new List<Pocion>(3);
   // public List<Vendaje> vendajes = new List<Vendaje>(6);

    public bool modoCombate;
    public GameObject iconoPociones;
    public GameObject iconoVendas;

    public GameObject barraDeVida;
    private float barraARellenar;
    public Color fullcolor;
    public Color lowColor;


    public bool enuso;

    public GameObject textoPociones;
    public GameObject textoMunicion;
    public GameObject textoVendajes;
    public GameObject textoDinero;
    public int pocionesTotales;
    public int PocionesTotales
    {
        get { return pocionesTotales; }
        set
        {
            if(value < 0)
            {
                Debug.Log("Alcanzado el minimo de pociones");
            }
            else
            {
                pocionesTotales = value;
            }
            if(value > 3)
            {
                Debug.Log("Alcanzado el maximo de Pociones");
            }
            else
            {
                pocionesTotales = value;
            }
        }
    }
    public int municionTotal;
    public int MunicionTotal
    {
        get { return municionTotal; }
        set
        {
            if (value < 0)
            {
                Debug.Log("Alcanzado el minimo de municion");
                municionTotal = 0;
            }
            else
            {
                municionTotal = value;
            }
            if (value > 6)
            {
                Debug.Log("Alcanzado el maximo de municion");
                municionTotal = 6;
            }
          
        }
    }
    public int vendajesTotales;
    public int VendajesTotales
    {
        get { return vendajesTotales; }
        set
        {
            if (value < 0)
            {
                Debug.Log("Alcanzado el minimo de vendajes");
            }
            else
            {
                vendajesTotales = value;
            }
            if (value > 6)
            {
                Debug.Log("Alcanzado el maximo de vendajes");
            }
            else
            {
                vendajesTotales = value;
            }
        }
    }


    public GameObject inventario;
    public GameObject gUI;
    public Sprite imagen ;
    public GameObject slot;

   public float fuerzaCasco = 0;
    public float DefensaCasco = 0;

    public float fuerzaPechera = 0;
    public float DefensaPechera = 0;

    public float fuerzaPantalon = 0;
    public float DefensaPantalon = 0;


    public float fuerzaBotas = 0;
    public float DefensaBotas = 0;

    public float fuerzaTotal = 0;
    public  float defensaTotal = 0;

    //este array string es el equipo dle jugador
    public string[] equipados = new string[4];
    //el sript que se inicia cuando le damos al pause debe:
    //mostrar el inventario
    //comprobar el equipo que tiene
    // Use this for initialization
    
	void Start () {


        if (modoCombate)
        {
            if (!iconoPociones.activeInHierarchy)
            {
                iconoPociones.SetActive(true);
            }
            if (iconoVendas.activeInHierarchy)
            {
                iconoVendas.SetActive(false);
            }
        }
        if (!modoCombate)
        {
            if (iconoPociones.activeInHierarchy)
            {
                iconoPociones.SetActive(false);
            }

            if (!iconoVendas.activeInHierarchy)
            {
                iconoVendas.SetActive(true);
            }
        }

            Debug.Log("Pociones al principio: " + PocionesTotales);
        
        enuso = false;

        

        //funcionalidades de los botones

        //salir del menu
        botonSalir.onClick.AddListener(salirInventario);
        //acceder a sets
        botonSets.onClick.AddListener(panelSets);
        //acceder a armaduras
        botonArmaduras.onClick.AddListener(panelArmaduras);
        //acceder a cascos
        botonCasco.onClick.AddListener(pestaña_Cascos);
        //acceder a pecheras
        botonPechera.onClick.AddListener(pestaña_Pechera);
        //acceder a pantalones
        botonPantalon.onClick.AddListener(pestaña_Pantalon);
        //acceder a botas
        botonBotas.onClick.AddListener(pestaña_botas);
        //*

       // Invoke( "pestaña_Cascos",1f);

       rellenarHuecosEquipados();
	}
	
	// Update is called once per frame
	void Update () {

     //   Debug.Log(GameObject.Find("ybot").GetComponent<CharaController>().EstoyEnPelea());
        //actualiza el dinero y municion que tiene player
        textoDinero.GetComponent<Text>().text = "x " + GameObject.Find("ybot").GetComponent<Inventario_Player>().dinero.ToString();
        textoMunicion.GetComponent<Text>().text = "x " + municionTotal.ToString();
        //agregamos a barraArellenar el valor entre 0 y 1 que debe añadir al fillamount para representar la vida
        barraARellenar = cantidadDeVidaEnLaBarra(GameObject.Find("ybot").GetComponent<Inventario_Player>().vidaPersonajeProvisional, 0, GameObject.Find("ybot").GetComponent<Inventario_Player>().vidaMaximaProvisional, 0, 1);
        barradeVida();
       
        
       
            if (GameObject.Find("ybot").GetComponent<CharaController>().EstoyEnPelea() == false)
            {
                modoCombate = false;
           
        
            }
            else
            {
                modoCombate = true;
            }
        

        if (modoCombate)
        {
            if (!iconoPociones.activeInHierarchy)
            {
                iconoPociones.SetActive(true);
            }
            if (iconoVendas.activeInHierarchy)
            {
                iconoVendas.SetActive(false);
            }
        }
        if (!modoCombate)
        {
            //if (iconoPociones.activeInHierarchy)
            //{
            //    iconoPociones.SetActive(false);
            //}

            //if (!iconoVendas.activeInHierarchy)
            //{
            //    iconoVendas.SetActive(true);
            //}
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (!iconoPociones.activeInHierarchy)
                {
                    iconoPociones.SetActive(true);
                }
                if (iconoVendas.activeInHierarchy)
                {
                    iconoVendas.SetActive(false);
                }
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (iconoPociones.activeInHierarchy)
                {
                    iconoPociones.SetActive(false);
                }

                if (!iconoVendas.activeInHierarchy)
                {
                    iconoVendas.SetActive(true);
                }
            }
        }
     


        if (Input.GetKeyDown(KeyCode.R))
        {
            //modo combate ON
            if (modoCombate && !enuso )
            {
                if (pocionesTotales > 0)
                {
                    enuso = true;
                    usarPocion();
                }
                else
                {
                    //NO QUEDAN MAS POCIONES---- aqui se le puede mostrar por GUI al jugador de ello
                    Debug.Log("No quedan mas pociones");
                }
            }
           
            
                
            
           if(!modoCombate)
            {
                if (vendajesTotales > 0 && iconoVendas.activeInHierarchy && !enuso)
                {
                    enuso = true;
                    usarVendaje();
                }
                else
                {
                    
                    
                }

                if (pocionesTotales > 0 && iconoPociones.activeInHierarchy && !enuso)
                {
                    enuso = true;
                    usarPocion();
                }
                else
                {
                  
                }

            }
        }
        //Debug.Log(Time.timeScale);

    }

    //metodo que recibe un string, recorre cada posicion del array dentro de cada posicion de la lista, luego se abre un swich y el parametro a comprobar (posicionArray.nombre.Split(' ')[0]  (esto devuelve la primera palabra de cada pieza))
    //en el caso de que sea casco, al slot 1 se le asigna el icono que representa a ese casco.
    public void equipar_equipamiento(string n)
    {
        foreach (var posicionesLista in Base_De_Datos.miInventario)
        {
            foreach (var posicionArray in posicionesLista)
            {
                
                if (posicionArray.icono.name == n)
                {
                    switch (posicionArray.nombre.Split(' ')[0])
                    {
                        case "Casco":

                            // si el casco ya está ocupado por un nombre, accede a el y quitale la E
                            desequipar_Equipamiento(transform.Find("Inventario").Find("Panel_Jugador").Find("Slot (1)").Find("ItemImage").GetComponent<Image>().sprite.name, transform.Find("Inventario").Find("Panel_Armaduras").Find("Panel_Casco").gameObject);
                            equipados[0] = posicionArray.nombre;
                            transform.Find("Inventario").Find("Panel_Jugador").Find("Slot (1)").Find("ItemImage").GetComponent<Image>().sprite = posicionArray.icono;
                            calculoDePoderTotalPorArmaduras(posicionArray.ataque, posicionArray.defensa, 0);

                            break;
                        case "Pechera":
                            desequipar_Equipamiento(transform.Find("Inventario").Find("Panel_Jugador").Find("Slot (2)").Find("ItemImage").GetComponent<Image>().sprite.name, transform.Find("Inventario").Find("Panel_Armaduras").Find("Panel_Pechera").gameObject);
                            equipados[1] = posicionArray.nombre;
                            transform.Find("Inventario").Find("Panel_Jugador").Find("Slot (2)").Find("ItemImage").GetComponent<Image>().sprite = posicionArray.icono;
                            calculoDePoderTotalPorArmaduras(posicionArray.ataque, posicionArray.defensa,1);
                            break;
                        case "Pantalon":

                            desequipar_Equipamiento(transform.Find("Inventario").Find("Panel_Jugador").Find("Slot (3)").Find("ItemImage").GetComponent<Image>().sprite.name, transform.Find("Inventario").Find("Panel_Armaduras").Find("Panel_Pantalon").gameObject);
                            equipados[2] = posicionArray.nombre;
                            transform.Find("Inventario").Find("Panel_Jugador").Find("Slot (3)").Find("ItemImage").GetComponent<Image>().sprite = posicionArray.icono;
                            calculoDePoderTotalPorArmaduras(posicionArray.ataque, posicionArray.defensa,2);
                            break;
                        case "Botas":

                            Debug.Log("nombre imagen de botas" + transform.Find("Inventario").Find("Panel_Jugador").Find("Slot (4)").Find("ItemImage").GetComponent<Image>().sprite.name);

                            desequipar_Equipamiento(transform.Find("Inventario").Find("Panel_Jugador").Find("Slot (4)").Find("ItemImage").GetComponent<Image>().sprite.name, transform.Find("Inventario").Find("Panel_Armaduras").Find("Panel_Botas").gameObject);
                           
                            equipados[3] = posicionArray.nombre;
                            transform.Find("Inventario").Find("Panel_Jugador").Find("Slot (4)").Find("ItemImage").GetComponent<Image>().sprite = posicionArray.icono;
                            calculoDePoderTotalPorArmaduras(posicionArray.ataque, posicionArray.defensa,3);
                            break;
                    }

                }
            
            }
        }


    }
    //un for anidado, primero la lista que engloba los arrays y despues los arrays
    void pestaña_Cascos()
    {
        if (!subpanel_cascos.activeInHierarchy)
        {
            
            subpanel_cascos.SetActive(true);

        }
        if (subpanel_Pecheras.activeInHierarchy)
        {
            //falta destruir todos los hijos(slots)de cada panel antes de cerrarlo
            //subpanel_Pecheras.
            subpanel_Pecheras.SetActive(false);

        }
        if (subpanel_Pantalone.activeInHierarchy)
        {
            //falta destruir todos los hijos(slots)de cada panel antes de cerrarlo
            subpanel_Pantalone.SetActive(false);

        }
        if (subpanel_Botas.activeInHierarchy)
        {
            //falta destruir todos los hijos(slots)de cada panel antes de cerrarlo
            subpanel_Botas.SetActive(false);

        }
        if (subpanel_cascos.transform.childCount == 0)
        {
            foreach (var posicionesLista in Base_De_Datos.miInventario)
            {
                foreach (var posicionArray in posicionesLista)
                {

                    Debug.Log(posicionArray.conseguida + "    " + posicionArray.nombre.Split(' ')[0]);
                    if (posicionArray.conseguida && posicionArray.nombre.Split(' ')[0] == "Casco")
                    {
                        Debug.Log("toca instanciar un casco");
                        GameObject aux = Instantiate(slot, transform.Find("Inventario").Find("Panel_Armaduras").Find("Panel_Casco"));

                        aux.transform.Find("ItemImage").GetComponent<Image>().sprite = posicionArray.icono;

                        //     aux.GetComponent<Objeto_contenido>().objeto_Contenido = posicionArray;

                    }

                }
            }
        }

    }

    void pestaña_Pechera()
    {
        //desactivamos las demas pestañas
        
        if (subpanel_cascos.activeInHierarchy)
        {
            //falta destruir todos los hijos(slots)de cada panel antes de cerrarlo
            subpanel_cascos.SetActive(false);

        }
        if (subpanel_Pantalone.activeInHierarchy)
        {
            //falta destruir todos los hijos(slots)de cada panel antes de cerrarlo
            subpanel_Pantalone.SetActive(false);

        }
        if (subpanel_Botas.activeInHierarchy)
        {
            //falta destruir todos los hijos(slots)de cada panel antes de cerrarlo
            subpanel_Botas.SetActive(false);

        }
        if (!subpanel_Pecheras.activeInHierarchy)
        {
            subpanel_Pecheras.SetActive(true);

        }
        if (subpanel_Pecheras.transform.childCount == 0)
        {
            foreach (var posicionesLista in Base_De_Datos.miInventario)
            {
                foreach (var posicionArray in posicionesLista)
                {

                    Debug.Log(posicionArray.conseguida + "    " + posicionArray.nombre.Split(' ')[0]);

                    if (posicionArray.conseguida && posicionArray.nombre.Split(' ')[0] == "Pechera")
                    {
                        GameObject aux = Instantiate(slot, transform.Find("Inventario").Find("Panel_Armaduras").Find("Panel_Pechera"));

                        aux.transform.Find("ItemImage").GetComponent<Image>().sprite = posicionArray.icono;

                        //     aux.GetComponent<Objeto_contenido>().objeto_Contenido = posicionArray;

                    }
                }
            }
        }

    }

    void pestaña_Pantalon()
    {
        //desactivamos las demas pestañas

        if (subpanel_cascos.activeInHierarchy)
        {
            //falta destruir todos los hijos(slots)de cada panel antes de cerrarlo
            subpanel_cascos.SetActive(false);
            Debug.Log("desactivando cascos");
        }
        if (subpanel_Pecheras.activeInHierarchy)
        {
            subpanel_Pecheras.SetActive(false);
            Debug.Log("desactivando pecheras");
        }
        if (subpanel_Botas.activeInHierarchy)
        {
            subpanel_Botas.SetActive(false);
            Debug.Log("desactivando botas");
        }
        if (!subpanel_Pantalone.activeInHierarchy)
        {
            subpanel_Pantalone.SetActive(true);
            Debug.Log("activando pantalones");
        }
        if (subpanel_Pantalone.transform.childCount == 0)
        {
            foreach (var posicionesLista in Base_De_Datos.miInventario)
            {
                foreach (var posicionArray in posicionesLista)
                {

                    Debug.Log(posicionArray.conseguida + "    " + posicionArray.nombre.Split(' ')[0]);

                    if (posicionArray.conseguida && posicionArray.nombre.Split(' ')[0] == "Pantalon")
                    {
                        GameObject aux = Instantiate(slot, transform.Find("Inventario").Find("Panel_Armaduras").Find("Panel_Pantalon"));

                        aux.transform.Find("ItemImage").GetComponent<Image>().sprite = posicionArray.icono;

                        //     aux.GetComponent<Objeto_contenido>().objeto_Contenido = posicionArray;

                    }
                }
            }
        }

    }

    void pestaña_botas()
    {
        //desactivamos las demas pestañas

        if (subpanel_cascos.activeInHierarchy)
        {
            //falta destruir todos los hijos(slots)de cada panel antes de cerrarlo
            subpanel_cascos.SetActive(false);

        }
        if (subpanel_Pecheras.activeInHierarchy)
        {
            subpanel_Pecheras.SetActive(false);

        }
        if (subpanel_Pantalone.activeInHierarchy)
        {
            subpanel_Pantalone.SetActive(false);

        }
        if (!subpanel_Botas.activeInHierarchy)
        {
            subpanel_Botas.SetActive(true);

        }
        if (subpanel_Botas.transform.childCount == 0)
        {
            foreach (var posicionesLista in Base_De_Datos.miInventario)
            {
                foreach (var posicionArray in posicionesLista)
                {

                    Debug.Log(posicionArray.conseguida + "    " + posicionArray.nombre.Split(' ')[0]);

                    if (posicionArray.conseguida && posicionArray.nombre.Split(' ')[0] == "Botas")
                    {
                        GameObject aux = Instantiate(slot, transform.Find("Inventario").Find("Panel_Armaduras").Find("Panel_Botas"));

                        aux.transform.Find("ItemImage").GetComponent<Image>().sprite = posicionArray.icono;

                        //     aux.GetComponent<Objeto_contenido>().objeto_Contenido = posicionArray;

                    }
                }
            }
        }

    }




    void rellenarHuecosEquipados()
    {
        if (equipados[0] == "")
        {
            transform.Find("Inventario").Find("Panel_Jugador").Find("Slot (1)").Find("ItemImage").GetComponent<Image>().sprite = imagen;
        }

        if (equipados[1] == "")
        {
            transform.Find("Inventario").Find("Panel_Jugador").Find("Slot (2)").Find("ItemImage").GetComponent<Image>().sprite = imagen;
        }

        if (equipados[2] == "")
        {
            transform.Find("Inventario").Find("Panel_Jugador").Find("Slot (3)").Find("ItemImage").GetComponent<Image>().sprite = imagen;
        }
        if (equipados[3] == "")
        {
            transform.Find("Inventario").Find("Panel_Jugador").Find("Slot (4)").Find("ItemImage").GetComponent<Image>().sprite = imagen;
        }

    }

    //metodos para funcionalidades de los botones

    //salir
    public void salirInventario()
    {
        if (Time.timeScale == 0 && inventario.activeInHierarchy && !gUI.activeInHierarchy)
        {

            Time.timeScale = 1;
            Debug.Log("que me salgo");
            inventario.SetActive(false);
            gUI.SetActive(true);
        }
        else Time.timeScale = 0;
    }
    //modo panel de sets
    public void panelSets()
    {

        Debug.Log("Has seleccionado el panel de SETS");
        if (panel_armaduras.activeInHierarchy)
        {
            panel_armaduras.SetActive(false);
        }
        if (!panel_sets.activeInHierarchy)
        {
            panel_sets.SetActive(true);
        }

        foreach (var posicionesLista in Base_De_Datos.miInventario)
        {
            foreach (var posicionArray in posicionesLista)
            {
                // hay que subir el alfa a 255 a las conseguidas

                //Debug.Log(transform.Find("Inventario").Find("Panel_Sets").Find("Viewport").Find("Content").Find("Set1_Vagabundo").Find("casco").Find("ItemImage").GetComponent<Image>().sprite.name);

                if (posicionArray.conseguida && posicionArray.nombre.Split(' ')[2] == "Vagabundo")
                {
                    switch (posicionArray.nombre.Split(' ')[0])
                    {
                        case "Casco":
                            transform.Find("Inventario").Find("Panel_Sets").Find("Viewport").Find("Content").Find("Set1_Vagabundo").Find("casco").Find("ItemImage").GetComponent<Image>().sprite = posicionArray.icono;
                            transform.Find("Inventario").Find("Panel_Sets").Find("Viewport").Find("Content").Find("Set1_Vagabundo").Find("casco").Find("ItemImage").GetComponent<Image>().color = new Color(255f, 255f, 255f);


                            break;

                        case "Pechera":
                            transform.Find("Inventario").Find("Panel_Sets").Find("Viewport").Find("Content").Find("Set1_Vagabundo").Find("Pechera").Find("ItemImage").GetComponent<Image>().sprite = posicionArray.icono;
                            transform.Find("Inventario").Find("Panel_Sets").Find("Viewport").Find("Content").Find("Set1_Vagabundo").Find("Pechera").Find("ItemImage").GetComponent<Image>().color = new Color(255f, 255f, 255f);
                            break;
                        case "Pantalon":
                            transform.Find("Inventario").Find("Panel_Sets").Find("Viewport").Find("Content").Find("Set1_Vagabundo").Find("Pantalones").Find("ItemImage").GetComponent<Image>().sprite = posicionArray.icono;
                            transform.Find("Inventario").Find("Panel_Sets").Find("Viewport").Find("Content").Find("Set1_Vagabundo").Find("Pantalones").Find("ItemImage").GetComponent<Image>().color = new Color(255f, 255f, 255f);
                            break;
                        case "Botas":
                            transform.Find("Inventario").Find("Panel_Sets").Find("Viewport").Find("Content").Find("Set1_Vagabundo").Find("Botas").Find("ItemImage").GetComponent<Image>().sprite = posicionArray.icono;
                            transform.Find("Inventario").Find("Panel_Sets").Find("Viewport").Find("Content").Find("Set1_Vagabundo").Find("Botas").Find("ItemImage").GetComponent<Image>().color = new Color(255f, 255f, 255f);
                            break;


                    }
                }

                    if (posicionArray.conseguida && posicionArray.nombre.Split(' ')[2] == "Dragon")
                    {
                        Debug.Log("hay una armadura de dragon que tienes");
                        switch (posicionArray.nombre.Split(' ')[0])
                        {
                            case "Casco":
                                transform.Find("Inventario").Find("Panel_Sets").Find("Viewport").Find("Content").Find("Set2_Dragon").Find("casco").Find("ItemImage").GetComponent<Image>().sprite = posicionArray.icono;
                                transform.Find("Inventario").Find("Panel_Sets").Find("Viewport").Find("Content").Find("Set2_Dragon").Find("casco").Find("ItemImage").GetComponent<Image>().color = new Color(255f, 255f, 255f);


                                break;

                            case "Pechera":
                                transform.Find("Inventario").Find("Panel_Sets").Find("Viewport").Find("Content").Find("Set2_Dragon").Find("Pechera").Find("ItemImage").GetComponent<Image>().sprite = posicionArray.icono;
                                transform.Find("Inventario").Find("Panel_Sets").Find("Viewport").Find("Content").Find("Set2_Dragon").Find("Pechera").Find("ItemImage").GetComponent<Image>().color = new Color(255f, 255f, 255f);
                                break;
                            case "Pantalon":
                                transform.Find("Inventario").Find("Panel_Sets").Find("Viewport").Find("Content").Find("Set2_Dragon").Find("Pantalones").Find("ItemImage").GetComponent<Image>().sprite = posicionArray.icono;
                                transform.Find("Inventario").Find("Panel_Sets").Find("Viewport").Find("Content").Find("Set2_Dragon").Find("Pantalones").Find("ItemImage").GetComponent<Image>().color = new Color(255f, 255f, 255f);
                                break;
                            case "Botas":
                                transform.Find("Inventario").Find("Panel_Sets").Find("Viewport").Find("Content").Find("Set2_Dragon").Find("Botas").Find("ItemImage").GetComponent<Image>().sprite = posicionArray.icono;
                                transform.Find("Inventario").Find("Panel_Sets").Find("Viewport").Find("Content").Find("Set2_Dragon").Find("Botas").Find("ItemImage").GetComponent<Image>().color = new Color(255f, 255f, 255f);
                                break;


                        }


                        //GameObject aux = Instantiate(slot, transform.Find("Inventario").Find("Panel_Armaduras").Find("Panel_Botas"));

                        //aux.transform.Find("ItemImage").GetComponent<Image>().sprite = posicionArray.icono;

                        //     aux.GetComponent<Objeto_contenido>().objeto_Contenido = posicionArray;

                    }
                
            }


        }
    }

        public void panelArmaduras()
        {
            Debug.Log("Has seleccionado el panel de Armaduras");

            if (!panel_armaduras.activeInHierarchy)
            {
                panel_armaduras.SetActive(true);
            }
            if (panel_sets.activeInHierarchy)
            {
                panel_sets.SetActive(false);
            }
        }
  public void calculoDePoderTotalPorArmaduras(float fue, float def, int tipo)
    {
       

        if(tipo == 0)
        {
            if(fuerzaCasco == 0 & DefensaCasco == 0)
            {
                fuerzaCasco += fue;
                DefensaCasco += def;
            }
            else
            {
                fuerzaCasco = fue;
                DefensaCasco = def;
            }
          
        }

        if (tipo == 1)
        {
            if (fuerzaPechera == 0 & DefensaPechera == 0)
            {
                fuerzaPechera += fue;
                DefensaPechera += def;
            }
            else
            {
                fuerzaPechera = fue;
                DefensaPechera = def;
            }

        }
        if (tipo == 2)
        {
            if (fuerzaPantalon == 0 & DefensaPantalon == 0)
            {
                fuerzaPantalon += fue;
                DefensaPantalon += def;
            }
            else
            {
                fuerzaPantalon = fue;
                DefensaPantalon = def;
            }

        }
        if (tipo == 3)
        {
            if (fuerzaBotas == 0 & DefensaBotas == 0)
            {
                fuerzaBotas += fue;
                DefensaBotas += def;
            }
            else
            {
                fuerzaBotas = fue;
                DefensaBotas = def;
            }

        }
        fuerzaTotal = fuerzaCasco + fuerzaPechera + fuerzaPantalon + fuerzaBotas;
        defensaTotal = DefensaCasco + DefensaPechera + DefensaPantalon + DefensaBotas;
        transform.Find("Inventario").Find("Panel_Jugador").Find("FuerzaTotal").GetComponent<Text>().text = "Fuerza: " + fuerzaTotal;
        transform.Find("Inventario").Find("Panel_Jugador").Find("DefensaTotal").GetComponent<Text>().text = "Defensa: " + defensaTotal;
        Debug.Log("Defensa total: " + defensaTotal);
        Debug.Log("Ataque total: " + fuerzaTotal);
    }

    public void desequipar_Equipamiento(string aux, GameObject panel)
    {
        for (int i = 0; i < panel.transform.childCount; i++)
        {
            if (panel.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().sprite.name == aux)
            {

                panel.transform.GetChild(i).transform.GetChild(0).GetChild(0).gameObject.SetActive(false);


            }



        }
       
             

            
        
    }

    void usarPocion()
    {
        // Debug.Log(GameObject.Find("ybot").GetComponent<Inventario_Player>().pociones[0].nombre);
        // pociones[0].consumir();
        //pociones.Remove(pociones[0]);
        if (GameObject.Find("ybot").GetComponent<Inventario_Player>().pociones.Count > 0)
        {
            GameObject.Find("ybot").GetComponent<Inventario_Player>().pociones[0].consumir();
            PocionesTotales--;
            GameObject.Find("ybot").GetComponent<Inventario_Player>().pociones.Remove(GameObject.Find("ybot").GetComponent<Inventario_Player>().pociones[0]);
            textoPociones.GetComponent<Text>().text = PocionesTotales.ToString();
            Debug.Log("Pociones restantes: " + (textoPociones.GetComponent<Text>().text = PocionesTotales.ToString()));
           
        }
    }

    void usarVendaje()
    {
        // Debug.Log(GameObject.Find("ybot").GetComponent<Inventario_Player>().pociones[0].nombre);
        // pociones[0].consumir();
        //pociones.Remove(pociones[0]);
        if (GameObject.Find("ybot").GetComponent<Inventario_Player>().vendajes.Count > 0)
        {
            GameObject.Find("ybot").GetComponent<Inventario_Player>().vendajes[0].Consumir();
            GameObject.Find("ybot").GetComponent<Inventario_Player>().vendajes.Remove(GameObject.Find("ybot").GetComponent<Inventario_Player>().vendajes[0]);
            vendajesTotales--;
            textoVendajes.GetComponent<Text>().text = vendajesTotales.ToString();
           // Debug.Log("Vendajes restantes: " + (textoVendajes.GetComponent<Text>().text = vendajesTotales.ToString()));
            
        }
    }
    

   public void barradeVida()
    {
        if(barraARellenar != barraDeVida.transform.Find("Mascara").Find("Image").GetComponent<Image>().fillAmount)
        {
           
            barraDeVida.transform.Find("Mascara").Find("Image").GetComponent<Image>().fillAmount = Mathf.Lerp(barraDeVida.transform.Find("Mascara").Find("Image").GetComponent<Image>().fillAmount, barraARellenar, Time.deltaTime * 2);
        }
        barraDeVida.transform.Find("Mascara").Find("Image").GetComponent<Image>().color = Color.Lerp(lowColor, fullcolor, barraARellenar);
    }
    //CALCULA LA UN VALOR ENTRE 0-1 EN RELACION A LA VIDA RESTANTE PARA PODER REPRESENTAR LA MISMA EN LA BARRA DE SALUD
    private float cantidadDeVidaEnLaBarra(float value, float inMin, float inMax, float outMin, float outMax)
    {
        // (vida que le queda  - vida minima(0))          *       (el 100% de la barra (1) - el 0% de la barra(0))          /        (vida maxima(1000) - vida minima(0) )        +       el 0% de la barra(0))
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;

    }

}
