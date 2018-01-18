using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class objeto_contenido_set : MonoBehaviour {

   

   public void LeerNombreImagen()
    {


        if (transform.Find("ItemImage").GetComponent<Image>().color.a == 1)
        {
            Debug.Log(transform.parent.parent.parent.parent.parent.parent);
            //esto pasa al scritp accede a inventario manager a su metodo equipar_equipamiento y le pasa como parametro el nombre de la imagen(que representa a cada pieza de equipamiento).
            transform.parent.parent.parent.parent.parent.parent.GetComponent<Inventario_Manager>().equipar_equipamiento(transform.GetChild(0).GetComponent<Image>().sprite.name);
            Debug.Log(transform.GetChild(0).GetComponent<Image>().sprite.name);
            // Debug.Log(transform.childCount);
            // Debug.Log(transform.GetChild(0).name);

            //esto pone el exto con la E verde on cuando es equipado
           

        }

    }
}
