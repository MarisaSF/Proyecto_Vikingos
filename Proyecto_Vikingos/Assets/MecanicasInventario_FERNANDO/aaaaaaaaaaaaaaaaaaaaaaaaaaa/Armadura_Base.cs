using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Armadura_Base : MonoBehaviour {

    public string tipoDeSet;
    public string nombre;
    public bool estaEquipada;
    public float ataque;
    public float defensa;
    public Sprite icono;
    public bool conseguida;

    public Armadura_Base(string tipoDeSet,string nombre, float ataque , float defensa, Sprite icono)

    {
        this.tipoDeSet = tipoDeSet;
        this.nombre = nombre;
        this.ataque = ataque;
        this.defensa = defensa;
        this.icono = icono;
        

        conseguida = false;
        estaEquipada =false;
    }

}
