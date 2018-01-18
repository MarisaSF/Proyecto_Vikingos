using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeleccionEnemyAttack : StateMachineBehaviour {
   
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        animator.GetComponent<EnemyManager>().modoataque = true;
	switch(animator.gameObject.GetComponent<EnemyManager>().ID)
    {
        case 1:
            animator.SetInteger("TipoDeEnemigo",1);
	break;
        case 2:
                
    animator.SetInteger("TipoDeEnemigo", 2);
    break;
        case 3:
    animator.SetInteger("TipoDeEnemigo", 3);
    break;
            
	}
    animator.gameObject.GetComponent<EnemyManager>().añadirlistPlayer();
}
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
	//}

	
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	
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
