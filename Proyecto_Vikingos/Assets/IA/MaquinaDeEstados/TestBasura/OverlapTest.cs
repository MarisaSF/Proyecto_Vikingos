using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class OverlapTest : MonoBehaviour {
    //Alejandro Rivas Carrillo || TheRivax || DateTime: 27/11/17 ||
    //Copyright Alejandro Rivas Carrillo || Todos los derechos reservados
    //Description: This script is a test of OverlapSphere

    #region Declaracion De variables
   //S public int center;
    public float radio;
    public float _PrimeraDistancia;

    public Collider[] PlayerColider;
    Transform playerTransform;
   public LayerMask SolPla;
    #endregion
    void Start () {
      
	}
	

	void Update () {
        Detect();

        if (Detect() == true)
        {
            Debug.Log("Player entra en rango de deteccion");
            Ray rallomackeen = new Ray(this.transform.position,playerTransform.position * -1);
            Debug.DrawRay(this.transform.position, playerTransform.position);
            RaycastHit info;
            if (Physics.Raycast(rallomackeen, out info,radio,SolPla))
            {
                Debug.Log("tirarayo");
                if (info.distance < _PrimeraDistancia)
                {
                    Debug.Log("Detectado");
                }
            }
        

    }
    }
    public bool Detect()
    {
        Debug.Log("1");
        PlayerColider = Physics.OverlapSphere(transform.position, radio);
        foreach (Collider col in PlayerColider)
        {
            Debug.Log("2");
            if (col.tag == "Player")
            {
               playerTransform= col.gameObject.GetComponent<Transform>();
                Debug.Log("3");
                return true;
               
            }
          
        }
       
        return false;
    }
}
