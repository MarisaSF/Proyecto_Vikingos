using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vendaje : Consumible_Base {

    public bool deCombate;

    public Vendaje(string nombre) : base(nombre)
    {
        this.deCombate = false;
    }


    public void Consumir()
    {
        if (!estaEnUso)
        {
            estaEnUso = true;
            //efecto
            GameObject.Find("Paquito").GetComponent<Consumible_Base>().StartCoroutine(CurasioAlTime());
        }
        else
        {

        }
    }

    public IEnumerator CurasioAlTime()
    {
        Debug.Log("consumir vendaje");

       
           
           
            //if(GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario_Player>().vidaPersonajeProvisional >= GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario_Player>().vidaMaximaProvisional)
            //{
            //    GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario_Player>().vidaPersonajeProvisional = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario_Player>().vidaMaximaProvisional;
            //}
            
        yield return new WaitForSeconds(2);
        Debug.Log("+ 15% de salud");
        GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario_Player>().VidaPersonajeProvisional += (15 * GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario_Player>().vidaMaximaProvisional) / 100;
        Debug.Log("Pasados los 2 segundos, puedes volver a curarte");
        estaEnUso = false;
        GameObject.Find("Canvas").GetComponent<Inventario_Manager>().enuso = false;
    }
}
