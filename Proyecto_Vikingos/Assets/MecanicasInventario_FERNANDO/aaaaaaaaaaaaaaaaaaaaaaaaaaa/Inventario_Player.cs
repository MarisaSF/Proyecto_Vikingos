using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario_Player : MonoBehaviour {


    /****************************************************************
   Este script establece y gestiona el inventario de player. La cantidad de pociones, vendas, armaduras, dinero, vida.

   David Lozano Ronda

   8/01/2018
   ****************************************************************/


    public Image iconico;
    public List<Pocion> pociones = new List<Pocion>(3);
    public List<Vendaje> vendajes = new List<Vendaje>(6);

    public bool  maximaMunicionAlcanzada;
    public bool maximasPocioneAlcanzada;
    public bool maximaVendaAlcanzada;



    public float vidaPersonajeProvisional;
    public float VidaPersonajeProvisional
    {
        get { return vidaPersonajeProvisional; }
        set
        {
            if (value >= vidaMaximaProvisional)
            {
                vidaPersonajeProvisional = vidaMaximaProvisional;
                Debug.Log("Vida Maxima Alcanzada");
            }
            else
            {
                vidaPersonajeProvisional = value;
            }
            if (VidaPersonajeProvisional <= 0)
            {
                vidaPersonajeProvisional = 0;
            }

        }
    }
    public float vidaMaximaProvisional;
    public int dinero;
    public int Dinero
    {
        get { return dinero; }
        set
        {
           if(Dinero <= 0)
            {
                dinero = 0;
            }
            else
           if (Dinero >= 9999)
            {
                dinero = 9999;
            }

            dinero = value;
        }
    }
  

    // Use this for initialization
    void Start () {
        
       // obtenerEquipo();
        
        vidaPersonajeProvisional = 200;
        vidaMaximaProvisional = 200;

        //Debug.Log(pociones.Count);
      //  Debug.Log(GameObject.Find("Canvas").GetComponent<Inventario_Manager>().textoPociones.GetComponent<Text>().text = GameObject.Find("Canvas").GetComponent<Inventario_Manager>().PocionesTotales.ToString());
        

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        

        //   Debug.Log(vidaPersonajeProvisional);

        //obtener pocion + vendaje
        //if (Input.GetKeyDown(KeyCode.R))
        //{

        //    obtenerPocion();
        //    obtenerVendaje();
        //    Debug.Log(pociones.Count);

        //}
        //restar  200 vida
        //if (Input.GetKeyDown(KeyCode.T))
        //{

        //    restarVida(34f);

        //}
        ////obtener dinero
        //if (Input.GetKeyDown(KeyCode.D))
        //{

        //    obtenerDinero(30);

        //}
        //if (Input.GetKeyDown(KeyCode.F))
        //{

        //    obtenerMunicion();

        //}
        //if (Input.GetKeyDown(KeyCode.U))
        //{

        //    restarMunicion();

        //}
    }

    public void obtenerEquipo(int set, int posicionArmadura)
    {
        //accede a base de datos ya que es una variable estatica y se puede acceder somplemente poniendo el nombre...
        //el primer parametro es la posicion de la lista y la segunda es la posicion del array en esa posicion de la lista


        Base_De_Datos.miInventario[set][posicionArmadura].conseguida = true;
        
       


    }

    public void obtenerPocion()
    {
        if (pociones.Count <= 3)
        {
            Pocion pocion1 = new Pocion("Brebaje de Hierbas");
            pociones.Add(pocion1);
            GameObject.Find("Canvas").GetComponent<Inventario_Manager>().PocionesTotales++;
            GameObject.Find("Canvas").GetComponent<Inventario_Manager>().textoPociones.GetComponent<Text>().text = (GameObject.Find("Canvas").GetComponent<Inventario_Manager>().PocionesTotales.ToString());
        }
        else
        {
            //NO SE PUEDEN OBTENER MAS POCIONES
            Debug.Log("Limite de pociones alcanzado");
        }
    }

    public void obtenerVendaje()
    {
        if (vendajes.Count <= 6)
        {
            Vendaje Vendaje1 = new Vendaje("Venda de papiro");
            vendajes.Add(Vendaje1);
            GameObject.Find("Canvas").GetComponent<Inventario_Manager>().vendajesTotales++;
            GameObject.Find("Canvas").GetComponent<Inventario_Manager>().textoVendajes.GetComponent<Text>().text = GameObject.Find("Canvas").GetComponent<Inventario_Manager>().vendajesTotales.ToString();
        }
        else
        {
            //NO SE PUEDEN OBTENER MAS POCIONES
            Debug.Log("Limite de Vendaje alcanzado");
        }
    }

    public void obtenerDinero(int cantidad)
    {
        Dinero += cantidad;
    }

    public void obtenerMunicion()
    {
        Debug.Log("suma flechas");
        GameObject.Find("Canvas").GetComponent<Inventario_Manager>().MunicionTotal++;
    }

    public void restarMunicion()
    {
        GameObject.Find("Canvas").GetComponent<Inventario_Manager>().MunicionTotal--;
    }

    public int municionDisponible()
    {
        return GameObject.Find("Canvas").GetComponent<Inventario_Manager>().MunicionTotal;
        
    }
    public float vidaRestante()
    {


        return VidaPersonajeProvisional;
    }

    public void restarVida(float value)
    {
        VidaPersonajeProvisional -= value;
    }
    public void sumarVida(float value)
    {
        VidaPersonajeProvisional += value;
    }
    public float fuerzaTotal()
    {
        return GameObject.Find("Canvas").GetComponent<Inventario_Manager>().fuerzaTotal;
    }
    public float defensaTotal()
    {
        return GameObject.Find("Canvas").GetComponent<Inventario_Manager>().defensaTotal;
    }

    public bool municionMaximaAlcanzada()
    {
        
        if(GameObject.Find("Canvas").GetComponent<Inventario_Manager>().MunicionTotal >= 6)
        {
            maximaMunicionAlcanzada = true;
        }
        else
        {
            maximaMunicionAlcanzada = false;

        }

        return maximaMunicionAlcanzada;
    }
    public bool pocionesMaximasAlcanzada()
    {

        if (GameObject.Find("Canvas").GetComponent<Inventario_Manager>().PocionesTotales >= 3)
        {
            maximasPocioneAlcanzada = true;
        }
        else
        {
            maximasPocioneAlcanzada = false;

        }

        return maximasPocioneAlcanzada;
    }
    public bool vendasMaximasAlcanzadas()
    {

        if (GameObject.Find("Canvas").GetComponent<Inventario_Manager>().VendajesTotales >= 6)
        {
            maximaVendaAlcanzada = true;
        }
        else
        {
            maximaVendaAlcanzada = false;

        }

        return maximaVendaAlcanzada;
    }

}
