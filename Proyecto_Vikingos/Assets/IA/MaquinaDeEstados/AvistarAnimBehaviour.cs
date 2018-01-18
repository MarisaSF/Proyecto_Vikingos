using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvistarAnimBehaviour : StateMachineBehaviour {
    
    ControladorVision controlvision;
    EnemyManager manager;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        controlvision=animator.GetComponent<ControladorVision>();
        manager = animator.GetComponent<EnemyManager>();
    }

   
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (controlvision.vealjugador() == true)
        {
            animator.SetBool("Avistado", true);
            Debug.Log("aRQUERO DISPARA");
            manager.TimerArcherState = 0;
     

        }
        else
        {
            animator.SetBool("Avistado", false);
        }
        float dis = Vector3.Distance(animator.transform.position, manager.target.position);
        // Debug.Log(dis);
        if (dis < manager.MaxDistanceArcher)
        {
            animator.SetBool("Avistado", false);
            Debug.Log("cambio a false");
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
