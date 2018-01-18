using UnityEngine;
using System.Collections;

public class CController : MonoBehaviour
{
 /*   public float speed = 6.0F;
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
    void Start()
    {
        //Time.timeScale = 0.5f;

        charAnimator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        camara = GameObject.Find("Main Camera");

    }
    /*   void LateUpdate()
       {


           Debug.Log(lastFrameJD);

       }*/
    /*void Update()
    {
        JI = IzquierdoJoystick();


        if (coroutineJD == null)
        {
            JD = DerechoJoystick();
        }

        if (!lastFrameJD && JD && DerechoJoystick() && coroutineJD != null) //Si acabo de pulsar JD y habia una corrutina activa
        {



            StopCoroutine(coroutineJD);
            coroutineJD = null;

        }
        else if (lastFrameJD && !JD && coroutineJD == null) //Si he dejado de pulsar JD
        {
            coroutineJD = DerechoJoystickRetarded();
            StartCoroutine(coroutineJD);
        }


        //      Debug.Log(leftHorizontalInput + "   " + leftVerticalInput);
        charAnimator.SetFloat("vel_X", leftHorizontalInput, 0.2f, Time.deltaTime * 1);
        charAnimator.SetFloat("vel_Z", leftVerticalInput, 0.2f, Time.deltaTime * 1);



        if (controller.isGrounded)
        {



            if (!JD && JI)
            {
                transform.Rotate(0, leftHorizontalInput, 0);





            }
            else if (JD && JI)
            {

                if (!lastFrameJI || blockJI)
                {
                    blockJI = true;

                    transform.rotation = Quaternion.Lerp(transform.rotation, GameObject.Find("Pivote_Camara_Y").transform.rotation, Time.deltaTime * 6);

                    float a = Vector3.Angle(transform.forward, GameObject.Find("Pivote_Camara_Y").transform.forward);

                    if (a < 1)
                    {
                        Debug.Log("FIN INTER");

                        blockJI = false;

                    }

                }
                else
                {
                    transform.Rotate(0f, rightHorizontalInput * rot_speed, 0);


                }



            }




            lastFrameJI = IzquierdoJoystick();


            lastFrameJD = DerechoJoystick();



        }


        moveDirection.y -= gravity * Time.deltaTime;


    }

    bool IzquierdoJoystick()
    {


        return (leftHorizontalInput != 0 || leftVerticalInput != 0) ? true : false;
    }


    bool DerechoJoystick()
    {



        return (rightVerticalInput != 0 || rightHorizontalInput != 0) ? true : false;
    }

    IEnumerator DerechoJoystickRetarded()
    {
        JD = true;
        yield return new WaitForSeconds(2);
        //   JD= false;
        coroutineJD = null;

    }


    public void SiendoGolpeado(float dmg)
    {
        vida -= dmg;

        if (vida > 0)
        {

            //VIVO


            charAnimator.SetBool("reciboDaño", true);
        }
        else
        {


            //MUERTO
            charAnimator.SetBool("muerto", true);


        }


    }*/
}