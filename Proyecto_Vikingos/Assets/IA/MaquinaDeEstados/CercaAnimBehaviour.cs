using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CercaAnimBehaviour : StateMachineBehaviour {

    EnemyManager manager;
    ControladorVision controlvis;
    ControladorNavMesh controlnav;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        manager = animator.GetComponent<EnemyManager>();
        controlvis = animator.GetComponent<ControladorVision>();
        controlnav = animator.GetComponent<ControladorNavMesh>();
        controlnav.quieto();
    }

  

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float dis = Vector3.Distance(animator.transform.position, manager.target.position);
     //   Debug.Log(dis);
        if (dis >= manager.MaxDistanceArcher)
        {
            animator.SetBool("Distancia", false);
            Debug.Log("cambio a false");
        }
        else if (dis < manager.MaxDistanceArcher)
        {
            controlnav.ActualizarTarget();
            if (controlnav.HeLlegado() == true)
            {
                animator.SetBool("Eleccion", true);
                Vector3 relativePos = manager.target.position - animator.transform.position;
                Quaternion rotation = Quaternion.LookRotation(relativePos);
               
                animator.transform.rotation = Quaternion.Slerp(animator.transform.rotation, rotation, Time.deltaTime * 2);
                Debug.Log("AtacaoCuerpoACupero");
            }
            if(controlnav.HeLlegado() == false)
            {

                animator.SetBool("Eleccion", false);
                Debug.Log("corro");
            }
            Debug.Log(animator.GetBool("Eleccion"));
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
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
