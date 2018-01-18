using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desarmado_Salto_SMBH : StateMachineBehaviour
{


    public float leftHorizontalInput;
    public float leftVerticalInput;
    //public float rightHorizontalInput;
    //public float rightVerticalInput;

    GameObject player;
    //GameObject mainCam;
    public Animator charAnimator;


    //public float dirX;
    //public float dirZ;

    //public float correccionDirZ;
    //public float correccionDirX;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.Find("ybot");
        //mainCam = GameObject.Find("Main Camera");
        charAnimator = player.GetComponent<Animator>();

        //dirX = leftHorizontalInput;
        //dirZ = leftVerticalInput;

    //    Debug.Log(leftHorizontalInput + "SMBH" + leftVerticalInput+"  "+ Time.frameCount);
    
        charAnimator.SetFloat("salto_X", leftHorizontalInput);
        charAnimator.SetFloat("salto_Z", leftVerticalInput);


        //correccionDirX = 0;
        //correccionDirZ = 0;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

      //  Vector3 forward = mainCam.transform.forward;
      //  Vector3 right = mainCam.transform.right;


      //  forward.y = 0f;
      //  right.y = 0f;
      //  forward.Normalize();
      //  right.Normalize();

      //  // float nDirZ = leftVerticalInput*
      //  /* float nDirZ = leftVerticalInput *
      //       float nDirX = leftVerticalInput **/
      //  //  Vector3 moveDirection = (forward* (dirZ-leftVerticalInput*0.2f))+ (right* (dirX - leftHorizontalInput* 0.2f));
      //  //   Vector3 moveDirection = (forward * (dirZ)) + (right * (dirX));


      //  dirZ += leftVerticalInput * 0.1f;
      //  dirX += leftHorizontalInput * 0.1f;
      // // Debug.Log("A " + dirZ + "   " + dirX);

      //  dirZ = Mathf.Clamp(dirZ, -1, 1);
      //  dirX = Mathf.Clamp(dirX, -1, 1);
      ////  Debug.Log("B " + dirZ + "   " + dirX);

      //  Vector3 moveDirection = (forward * dirZ) + (right * dirX);

      //  //  Debug.Log("MOVIENDOOO");
      //  //   UnityEditor.EditorApplication.isPaused = true;
      //  // player.GetComponent<CharacterController>().Move(moveDirection * Time.deltaTime * 2.5f);
      // // player.GetComponent<CharaManager>().StartCoroutine(Mv(moveDirection));


    }
      
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        //  player.GetComponent<CharaManager>().btnEspacio = false;
        //  charAnimator.SetBool("espacio", false);
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
