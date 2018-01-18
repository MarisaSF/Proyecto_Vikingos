using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pocion : Consumible_Base {
    public bool deCombate;

    public Pocion(string nombre) : base(nombre)
    {
        this.deCombate = true;
    }

    public void  consumir()
    {
        if (!estaEnUso)
        {
            estaEnUso = true;
            //efecto
           GameObject.Find("Paquito").GetComponent<Consumible_Base>().StartCoroutine(CurasioPorTime());
        }
        else
        {

        }
    }

    public IEnumerator CurasioPorTime()
    {
        Debug.Log("consumir pocion");

        for (int i = 0; i < 6; i++)
        {
            Debug.Log("1SEGUNDO");
            GameObject.Find("ybot").GetComponent<Inventario_Player>().VidaPersonajeProvisional += (5 * GameObject.Find("ybot").GetComponent<Inventario_Player>().vidaMaximaProvisional) / 100;
            //if(GameObject.Find("ybot").GetComponent<Inventario_Player>().VidaPersonajeProvisional >= GameObject.Find("ybot").GetComponent<Inventario_Player>().vidaMaximaProvisional)
            //{
            //    GameObject.Find("ybot").GetComponent<Inventario_Player>().VidaPersonajeProvisional = GameObject.Find("ybot").GetComponent<Inventario_Player>().vidaMaximaProvisional;
            //}
            Debug.Log("+ 5% de salud");
            yield return new WaitForSeconds(1);
           
        }
        




        
        Debug.Log("Pos ya son 6 segundos, puedes volver a curarte");
        estaEnUso = false;
        GameObject.Find("Canvas").GetComponent<Inventario_Manager>().enuso = false;
    }
}
