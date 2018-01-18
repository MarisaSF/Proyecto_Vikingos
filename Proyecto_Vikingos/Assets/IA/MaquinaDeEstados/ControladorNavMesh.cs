using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//Alejandro Rivas Carrillo || TheRivax || DateTime: 03/12/17 ||
//Copyright Alejandro Rivas Carrillo || Todos los derechos reservados
//Description: 
public class ControladorNavMesh : MonoBehaviour {
    //Componente auxiliar, toda la logica del navmeshAgent
    [HideInInspector]
   NavMeshAgent agente;
   public Transform Target;
    float _deltaTime;
    
	void Start () {
        agente = this.gameObject.GetComponent<NavMeshAgent>();
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
	}
	
	
	void Update () {
		
	}
    //NuevoDestino
    public void ActualizarTarget(Vector3 NuevoTarget)
    {
       
        agente.destination=NuevoTarget;
       
        
    }
    public void adelante()
    {
        agente.isStopped = false;
    }
    //Metodo para dejar parado al Enemigo
    public void quieto()
    {
        agente.isStopped = true;
    }
    //Modificacion echa el 06/12/2017
    // 
    //public void quieto(float tiempo, MyStateBase estado )
    //{
    //    _deltaTime += Time.deltaTime;
    //    if (_deltaTime < tiempo)
    //    {
    //        quieto();
    //    }
    //    else
    //    {
    //        maquina.cambiaestado(estado); 
    //    }
    //}
    //Para saber si he llegado o no
    public bool HeLlegado()
    {
        //ActualizarTarget();
        //remainingdistance es la distancia que falta para llegar al punto, stopping para saber la distancia que tenemos para detener al bicho y pathpending es para saber que no ahi mas camino pendiente por caminar
       if(( agente.remainingDistance<= agente.stoppingDistance)&& !agente.pathPending)
        {
           // Debug.Log("He llegado");
            return true;
          
        }
        else
        {
           // Debug.Log("No He llegado");
            return false;
        }
    }
    public void ActualizarTarget()
    {
        ActualizarTarget(Target.position);

    }
    
}
