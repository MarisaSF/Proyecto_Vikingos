using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Andar_Desarmado_SMBH : StateMachineBehaviour
{

    GameObject player;

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float rot_speed = 1.0f;
    public float gravity = 20.0F;


    public Animator charAnimator;
    CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;


    public float leftHorizontalInput;
    public float leftVerticalInput;
    public float rightHorizontalInput;
    public float rightVerticalInput;

    public float vida;

    public float rotYPers = 0;

    public GameObject camara;


    public bool JI = false;
    public bool JD = false;

    public bool lastFrameJI = false;

    public bool lastFrameJD = false;

    public IEnumerator coroutineJD = null;

    public bool blockJI = false;

    public bool lShift = false;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        player = GameObject.Find("ybot");


        charAnimator = player.GetComponent<Animator>();
        controller = player.GetComponent<CharacterController>();
        camara = GameObject.Find("Main Camera");



        //       Debug.Log("ENTRO A CORRER");


    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        //Debug.Log("antes " + player.transform.rotation.eulerAngles);

        //player.transform.Rotate(0, 10, 0);






        JI = IzquierdoJoystick();


        if (coroutineJD == null)
        {
            JD = DerechoJoystick();
        }




        //       Debug.Log(lastFrameJD + "  " + JD + "    " + DerechoJoystick() + "    " + coroutineJD);
        if (!lastFrameJD && JD && DerechoJoystick() && coroutineJD != null) //Si acabo de pulsar JD y habia una corrutina activa
        {
            //     UnityEditor.EditorApplication.isPaused = true;
            //           Debug.Log("CANCEL RETARDO");

            player.GetComponent<CharaManager>().StopCoroutine(coroutineJD);
            coroutineJD = null;

        }
        else if (lastFrameJD && !JD && coroutineJD == null) //Si he dejado de pulsar JD
        {
            //      Debug.Log("LLAMO RETARDO");

            coroutineJD = DerechoJoystickRetarded();
            player.GetComponent<CharaManager>().StartCoroutine(coroutineJD);
        }


        //      Debug.Log(leftHorizontalInput + "   " + leftVerticalInput);
        charAnimator.SetFloat("vel_X", leftHorizontalInput, 0.2f, Time.deltaTime * 1);
        charAnimator.SetFloat("vel_Z", leftVerticalInput, 0.2f, Time.deltaTime * 1);
        charAnimator.SetBool("shift", lShift);



        if (controller.isGrounded)
        {


            if (!JD && JI)
            {


                //   Debug.Log("antes " + player.transform.rotation.eulerAngles);

                ///   player.transform.Rotate(0, leftHorizontalInput, 0);


                player.GetComponent<CharaManager>().StartCoroutine(RotatePlayer(leftHorizontalInput));

                //   Debug.Log("despes " + player.transform.rotation.eulerAngles);





            }
            else if (JD && JI)
            {
             //   Debug.Log("Yo voyasd fsljfla rotar desde aqui");

                if (!lastFrameJI || blockJI)
                {

                    blockJI = true;

                    //player.transform.rotation = Quaternion.Lerp(player.transform.rotation, GameObject.Find("Pivote_Camara_Y").transform.rotation, Time.deltaTime * 6);
                    player.GetComponent<CharaManager>().StartCoroutine(RotationPlayer());

                    float a = Vector3.Angle(player.transform.forward, GameObject.Find("Pivote_Camara_Y").transform.forward);

                    if (a < 1)
                    {
                   //     Debug.Log("FIN INTER");

                        //     Debug.Log("FIN INTER");

                        blockJI = false;

                    }

                }
                else
                {

                    //  player.transform.Rotate(0f, rightHorizontalInput * rot_speed, 0);

                    //  player.GetComponent<CharaManager>().GirarPlayer(rightHorizontalInput * rot_speed);
                    player.GetComponent<CharaManager>().StartCoroutine(RotatePlayer(rightHorizontalInput * rot_speed));

                }



            }




            lastFrameJI = IzquierdoJoystick();


            lastFrameJD = DerechoJoystick();



        }


        moveDirection.y -= gravity * Time.deltaTime;
        //     Debug.Log("despes " + player.transform.rotation.eulerAngles);

    }

    bool IzquierdoJoystick()
    {


        return (leftHorizontalInput != 0 || leftVerticalInput != 0) ? true : false;
    }


    bool DerechoJoystick()
    {



        return (rightVerticalInput != 0 || rightHorizontalInput != 0) ? true : false;
    }
    IEnumerator RotationPlayer()
    {
        yield return new WaitForEndOfFrame();


        player.transform.rotation = Quaternion.Lerp(player.transform.rotation, GameObject.Find("Pivote_Camara_Y").transform.rotation, Time.deltaTime * 6);

    }


    IEnumerator RotatePlayer(float f)
    {

        yield return new WaitForEndOfFrame();

        player.transform.Rotate(0, f, 0);
    }
    IEnumerator DerechoJoystickRetarded()
    {
        JD = true;

        float t = Time.time;
        //     Debug.Log("RETARDOO");
        yield return new WaitForSeconds(2);
        //    Debug.Log("FIN RETARDO"+ (Time.time-t));


        //   JD= false;
        coroutineJD = null;

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
