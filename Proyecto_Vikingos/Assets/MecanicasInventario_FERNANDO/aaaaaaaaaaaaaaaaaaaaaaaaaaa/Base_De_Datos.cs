using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Base_De_Datos : MonoBehaviour {

    public static List<Armadura_Base[]> miInventario =  new List<Armadura_Base[]>();
    /****************************************************************
   Este script contiene la base de datos de armaduras.

   David Lozano Ronda

   8/01/2018
   ****************************************************************/


    void Awake()
     {
         //Set 1
         // Set del guerrero
         //carga todas las imagenes y asigna la de indice 0 a "aux"

         Armadura_Base[] set = new Armadura_Base[4];

         Casco aux_Cas = new Casco("De Dragon", "Casco De Dragon", 5, 0, Resources.LoadAll<Sprite>("MedievalArmors") [11]);

         Pechera aux_Pec = new Pechera("De Dragon", "Pechera De Dragon", 8, 5, Resources.LoadAll<Sprite>("MedievalArmors")[10]);

         Pantalones aux_Pan = new Pantalones("De Dragon", "Pantalon De Dragon", 6, 0, Resources.LoadAll<Sprite>("pants")[0]);

        Botas aux_Bot = new Botas("De Dragon", "Botas De Dragon", 5, 3, Resources.LoadAll<Sprite>("MedievalArmors")[9]);

        set[0] = aux_Cas;
         set[1] = aux_Pec;
         set[2] = aux_Pan;
         set[3] = aux_Bot;

         miInventario.Add(set);

         //Set 2
         //set de explorador

         Armadura_Base[] set2 = new Armadura_Base[4];

         Casco aux_Cas2 = new Casco("De Vagabundo", "Casco De Vagabundo", 0, 5, Resources.LoadAll<Sprite>("MedievalArmors")[4]);

         Pechera aux_Pec2 = new Pechera("De Dragon", "Pechera De Vagabundo", 5, 8, Resources.LoadAll<Sprite>("MedievalArmors")[7]);

         Pantalones aux_Pan2 = new Pantalones("De Dragon", "Pantalon De Vagabundo", 0, 6, Resources.LoadAll<Sprite>("pants")[1]);

        Botas aux_Bot2 = new Botas("De Dragon", "Botas De Vagabundo", 3, 5, Resources.LoadAll<Sprite>("MedievalArmors")[5]);

        set2[0] = aux_Cas2;
         set2[1] = aux_Pec2;
         set2[2] = aux_Pan2;
         set2[3] = aux_Bot2;

         miInventario.Add(set2);




    //   Debug.Log(miInventario[0][0].nombre);
     }





}
