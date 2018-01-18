using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorVision : MonoBehaviour {
    //Alejandro Rivas Carrillo || TheRivax || DateTime: 05/12/17 ||
    //Copyright Alejandro Rivas Carrillo || Todos los derechos reservados
    //Description: 
    public Transform ojos;
    public float rangoVision = 20f;
    public Vector3 offset = new Vector3(0f, 0.5f, 0f);
    ControladorNavMesh controladornavmesh;
    Transform target;
    bool ver = false;
    private void Start()
    {
        controladornavmesh = GetComponent<ControladorNavMesh>();
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    public bool vealjugador(out RaycastHit hit, bool mirarhaciaeljugador = false)
    {
        Vector3 vectdir;
        if (mirarhaciaeljugador)
        {
            vectdir = (controladornavmesh.Target.position + offset) - ojos.position;
        }
        else
        {
            vectdir = ojos.forward;
        }
        Debug.Log(Physics.Raycast(ojos.position, vectdir, out hit, rangoVision) && hit.collider.CompareTag("Player"));
        Debug.DrawRay(ojos.position, vectdir, Color.blue);
        return Physics.Raycast(ojos.position, vectdir,out hit,rangoVision) && hit.collider.CompareTag("Player");
        
    }
    public bool vealjugador()
    {
        Vector3 targetDir = target.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
       float calculo= Vector3.Distance(target.position, transform.position);
        RaycastHit hit;
        if (ver == true) { return true; }
        if ((angle < 60.0f)&&(calculo<rangoVision))
        {
            // Debug.Log(angle);
            Vector3 origin =transform.TransformPoint(ojos.localPosition);
            Vector3 destination = target.position + offset;

            Debug.DrawLine(origin, destination);
            Vector3 direccion =  (target.position - ojos.position ) +new Vector3(0,0.5f,0) ;
          
            //Debug.Log("direccion"+direccion);
           // Debug.Log("Direccion + Offset" + (direccion + offset));
            //TODOO Tirar raycast para comprobar que no ahi ningun obstaculo entre jugador y enemigo

           if( Physics.Raycast(origin , direccion, out hit, rangoVision) && hit.collider.CompareTag("Player"))

            {
                Debug.Log("Detectado");
                return true;
            }
            else
            {
                return false;
            }
           
        }
        else
        {
            return false ;
        }
      
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ver = true;
        }
    }
}
    
