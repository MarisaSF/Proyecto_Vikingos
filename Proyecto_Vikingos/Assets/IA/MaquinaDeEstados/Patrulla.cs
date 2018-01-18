using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Patrulla : StateMachineBehaviour {

    ControladorNavMesh controlnav;
    NavMeshAgent navagent;
    ControladorVision controlvis;
    EnemyManager components;
    int puntoact;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controlnav = animator.gameObject.GetComponent<ControladorNavMesh>();
        controlvis = animator.gameObject.GetComponent<ControladorVision>();
        navagent = animator.gameObject.GetComponent<NavMeshAgent>();
        components = animator.gameObject.GetComponent<EnemyManager>();
        navagent.speed = components.VelAndar;
        navagent.autoBraking = false;
        navagent.stoppingDistance = 0.1f;
       // controlnav.Target = components.puntos[0];
       // controlnav.ActualizarTarget();
       // Debug.Log(controlnav.agente.destination);

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        if (controlvis.vealjugador() == true)
        {
            Debug.Log("veo al player");
            //TODO CambiaEstadoPerecucion 
            if (components.ID == 3) { animator.SetTrigger("attack"); }
            else
            {
                animator.SetTrigger("run1");
            }
            return;
        }
        if ((controlnav.HeLlegado() == true) )
        {
            Debug.Log(puntoact);
            controlnav.ActualizarTarget(components.puntos[puntoact].transform.position);
            puntoact++;
            if (puntoact == components.puntos.Length) { puntoact = 0; Debug.Log("ruta completada"); }

           // controlnav.ActualizarTarget(components.puntos[puntoact].transform.position);

        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
