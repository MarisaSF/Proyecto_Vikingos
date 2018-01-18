using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pantalones : Armadura_Base
{

	 public  int posicionDeEquipo;

     public Pantalones(string tipoDeSet, string nombre, float ataque, float defensa, Sprite icono )
      : base(tipoDeSet, nombre, ataque, defensa, icono)
    {
        this.posicionDeEquipo = 2;
    }
}
