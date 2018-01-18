using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// dependiendo del tiempo que pase sin avistarte
public class LejosAnimBehaviour : StateMachineBehaviour {
     float tiempo;
     float MaxTime;
    bool una;
    EnemyManager manager;
    ControladorVision controlvis;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        manager = animator.GetComponent<EnemyManager>();
        tiempo = manager.TimerArcherState;
        MaxTime = manager.MaxTimerArcherState;
        controlvis = animator.GetComponent<ControladorVision>();
    }

 

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tiempo += Time.deltaTime;
        tiempo = manager.TimerArcherState;
        if ((tiempo > MaxTime)|| (controlvis.vealjugador() == false))
        {
            animator.SetBool("Lejos", true);
            manager.TimerArcherState = 0;
        }
        else
        {
            float dis = Vector3.Distance(animator.transform.position, manager.target.position);
          //  Debug.Log(dis);
            if (dis >= manager.MaxDistanceArcher)
            {
                animator.SetBool("Distancia", false);
            //    Debug.Log("cambio a false");
            }
            else if (dis < manager.MaxDistanceArcher) 
            {
                animator.SetBool("Distancia", true);
             //   Debug.Log("cambio a true");
            }
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
