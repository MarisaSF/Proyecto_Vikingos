using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Consumible_Base : MonoBehaviour {

    public string nombre;
    public bool estaEnUso ;

    public Consumible_Base(string nombre)
    {

        this.nombre = nombre;
       
    }
 

    public void consumir()
    {

        if (!estaEnUso)
        {
            estaEnUso = true;
            //efecto
        }
        else
        {

        }
    }


}
