using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Perseucion : StateMachineBehaviour {
    ControladorNavMesh controlnav;
    NavMeshAgent navagent;
    ControladorVision controlvis;
    EnemyManager enemy;
	
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        controlnav = animator.gameObject.GetComponent<ControladorNavMesh>();
        controlvis = animator.gameObject.GetComponent<ControladorVision>();
        navagent = animator.gameObject.GetComponent<NavMeshAgent>();
        enemy = animator.gameObject.GetComponent<EnemyManager>();
        navagent.autoBraking = true;
       navagent.stoppingDistance = enemy.Distance;
      navagent.speed = 4; // velocidadPersecucion
        controlnav.ActualizarTarget();
        enemy.modoataque = true;
        navagent.speed = enemy.VelCorrer;
        
	}

	 
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (enemy.ID == 3) { animator.SetTrigger("attack"); }
        if (controlnav.HeLlegado() == true)
        {
            animator.SetTrigger("attack");
            Debug.Log("Entra en submaquina");
          //TODOO Cambiar a submaquina de estados combate
        }
        else
        {
            controlnav.ActualizarTarget();

        }
	}

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        navagent.autoBraking = false;
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
