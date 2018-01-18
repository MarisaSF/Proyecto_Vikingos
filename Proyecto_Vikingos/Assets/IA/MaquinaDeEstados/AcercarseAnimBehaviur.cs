using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AcercarseAnimBehaviur : StateMachineBehaviour {
    ControladorNavMesh controlnav;
    EnemyManager enemymanager;
    NavMeshAgent agente;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agente = animator.GetComponent<NavMeshAgent>();
        enemymanager = animator.GetComponent<EnemyManager>();
        controlnav = animator.GetComponent<ControladorNavMesh>();
        controlnav.ActualizarTarget();
        controlnav.adelante();
        agente.speed = enemymanager.VelAndar;
        agente.stoppingDistance = enemymanager.Distance;
        agente.autoBraking = true;
        controlnav.adelante();
        Debug.Log("Acercarse");
    }

	
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        controlnav.ActualizarTarget();
        if (controlnav.HeLlegado() == true)
        {
            animator.SetBool("EleccionAM", true);
        }
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
