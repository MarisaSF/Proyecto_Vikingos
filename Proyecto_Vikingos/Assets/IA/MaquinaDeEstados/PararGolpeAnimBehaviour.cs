using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PararGolpeAnimBehaviour : StateMachineBehaviour {

    ControladorNavMesh navmesh;
    EnemyManager manager;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        navmesh = animator.GetComponent<ControladorNavMesh>();
        navmesh.quieto();
        manager=animator.GetComponent<EnemyManager>();
        
    }



    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      
    }

  

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        manager.modoataque = true;
        navmesh.ActualizarTarget();
        navmesh.adelante();
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
