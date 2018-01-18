using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2 : MonoBehaviour
{

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public float maxFallSpeed = -8F;
    private Vector3 moveDirection = Vector3.zero;

    private CharacterController cc;
    private Animator ac;

    public Transform cameraTransform;

    public float leftHorizontalInput;
    public float leftVerticalInput;

    public bool jump;

    public float topeY = -1;

    //Use this for initialization
    void Start()
    {

        ac = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
    }


    void Update()
    {

        GetComponent<Animator>().SetFloat("vel_X", leftHorizontalInput);
        GetComponent<Animator>().SetFloat("vel_Z", leftVerticalInput);

        //Transforma el vector forward de la cámara de coordenadas locales a coordenadas de mundo
        Vector3 forward = cameraTransform.TransformDirection(Vector3.forward);
        Debug.Log("CAM " + cameraTransform.forward + "  trans " + forward);

        forward.y = 0;
        forward = forward.normalized;

        Vector3 right = new Vector3(forward.z, 0, -forward.x);

        Vector3 inputVec = leftHorizontalInput * right + leftVerticalInput * forward;

        if (inputVec.x != 0 || inputVec.z != 0)
        {
            moveDirection.x = inputVec.x * speed;
            moveDirection.z = inputVec.z * speed;

          //  ac.SetBool("isWalking", true);

       
           // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(inputVec), Time.deltaTime * 10);
        }
        else
        {
            moveDirection.x = 0;
            moveDirection.z = 0;

         //   ac.SetBool("isWalking", false);



        }
        if (cc.isGrounded)
        {
        //    ac.SetBool("jump", false);


            if (jump)
            {
                //     ac.SetBool("jump", true);
                ac.SetBool("jumoTrig", true);
                moveDirection.y = jumpSpeed;
                jump = false;

            }

        } else
        {
            moveDirection.y -= gravity * Time.deltaTime;


        }



        //Capa la Y
       if (moveDirection.y < maxFallSpeed)
           {
               moveDirection.y = maxFallSpeed;
           }

     

        //Debug.Log(topeY);
        cc.Move(moveDirection * Time.deltaTime);
    ///////////////////////////////////////  ac.SetFloat("velY", cc.velocity.y);
    ///////////////////////////////////////    ac.SetBool("isGrounded", cc.isGrounded);
   
    }


   /* public void ATK()
    {

        if (GetComponent<ComboManager>().enabled == true)
        {

            GetComponent<ComboManager>().quieroATK =true;

        }
        else
        {

            GetComponent<ComboManager>().enabled = true;

        }

    }*/
}
