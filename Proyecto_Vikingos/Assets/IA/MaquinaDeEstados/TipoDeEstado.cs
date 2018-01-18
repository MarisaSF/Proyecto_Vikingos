using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TipoDeEstado : StateMachineBehaviour {

    NavMeshAgent agente;
    ControladorNavMesh controlnav;
    EnemyManager manager;
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        agente = animator.GetComponent<NavMeshAgent>();
        controlnav = animator.GetComponent<ControladorNavMesh>();
        manager = animator.GetComponent<EnemyManager>();
        controlnav.ActualizarTarget();
        controlnav.quieto();
        switch (manager.ID)
        {
            case 1:
                if ((agente.remainingDistance <= agente.stoppingDistance) && !agente.pathPending)
                {
                    animator.SetBool("EleccionAM", true);
                    animator.transform.LookAt(manager.target.position); // replantear
                    
                    Debug.Log("Ataco");
                }
              
                else
                {

                    animator.SetBool("EleccionAM", false);
                    Debug.Log("Me acerco");
                }
                break;
            case 2:
                if ((agente.remainingDistance <= agente.stoppingDistance) && !agente.pathPending)
                {
                    animator.SetBool("EleccionAM", true);
                    Debug.Log("Ataco");
                }

                else
                {

                    animator.SetBool("EleccionAM", false);
                    Debug.Log("Me acerco");
                }
                break;
            case 3:
                float dis = Vector3.Distance(animator.transform.position, manager.target.position);
                controlnav.quieto();
                if (dis >= manager.MaxDistanceArcher)
                {
                    animator.SetBool("Distancia", false);
                }
                else
                {
                    animator.SetBool("Distancia", true);
                }

                break;
        }
        
        
	
	}

	
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
    //}

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
