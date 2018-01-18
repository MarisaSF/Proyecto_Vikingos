using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleBehaviour : StateMachineBehaviour {
    ControladorNavMesh controlnav;
    EnemyManager manager;
    ControladorVision controlvis;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controlnav=animator.gameObject.GetComponent<ControladorNavMesh>();
        controlvis = animator.gameObject.GetComponent<ControladorVision>();
        manager = animator.gameObject.GetComponent<EnemyManager>();
        controlnav.quieto();
    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        if (controlvis.vealjugador() == true)
        {
            //Debug.Log("tira");
            if (manager.ID == 3) {

                animator.SetTrigger("attack");
                Debug.Log("ID3");
            }
            else
            {
                animator.SetTrigger("run1");
            }
        }
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        controlnav.adelante();
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
