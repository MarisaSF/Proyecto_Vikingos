using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botas : Armadura_Base
{

 public  int posicionDeEquipo;

 public Botas(string tipoDeSet, string nombre, float ataque, float defensa, Sprite icono)
      : base(tipoDeSet, nombre, ataque, defensa, icono)
    {
        this.posicionDeEquipo = 3;
    }
}
