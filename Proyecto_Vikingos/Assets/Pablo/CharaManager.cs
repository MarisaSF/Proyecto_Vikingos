using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaManager : MonoBehaviour
{
    public GameObject puntoDeMira;

    Animator animatorC;



    public float leftHorizontalInput;
    public float leftVerticalInput;
    public float rightHorizontalInput;
    public float rightVerticalInput;

    public bool JD = false;
    public bool JI = false;
    public bool blockJI = false;


    public bool lShift = false;

    public bool btnC = false;



    public bool btnEspacio = false;

    public bool LMB = false;
    public bool RMB = false;

    public bool combo = false;



    //test velocidad


    public float maxSpeed = 0;
    public float minSpeed = 100;
    public List<float> vels = new List<float>();
    // Use this for initialization
    void Start()
    {

        animatorC = GetComponent<Animator>();
      
    }


    // Update is called once per frame
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();
        Vector3 horizontalVelocity = controller.velocity;
        horizontalVelocity = new Vector3(controller.velocity.x, 0, controller.velocity.z);
        float horizontalSpeed = horizontalVelocity.magnitude;
        float verticalSpeed = controller.velocity.y;
        float overallSpeed = controller.velocity.magnitude;
       
     //   Debug.Log("overall " + overallSpeed);
        //vels.Add(overallSpeed);
      //  vels.Sort();
        //  Debug.Log(GetComponent<CharacterController>().velocity);


        /*  if (!animatorC.GetBool("espacio"))
          {
              btnEspacio = false;
          }*/

        AnimatorStateInfo a = animatorC.GetCurrentAnimatorStateInfo(0);


        animatorC.GetBehaviour<Desarmado_SMBH>().leftHorizontalInput = leftHorizontalInput;
        animatorC.GetBehaviour<Desarmado_SMBH>().leftVerticalInput = leftVerticalInput;
        animatorC.GetBehaviour<Desarmado_SMBH>().rightHorizontalInput = rightHorizontalInput;
        animatorC.GetBehaviour<Desarmado_SMBH>().rightVerticalInput = rightVerticalInput;
        animatorC.GetBehaviour<Desarmado_SMBH>().lShift = lShift;
        animatorC.GetBehaviour<Desarmado_SMBH>().btnC = btnC;
        animatorC.GetBehaviour<Desarmado_SMBH>().btnEspacio = btnEspacio;

        animatorC.GetBehaviour<Desarmado_SMBH>().LMB = LMB;

        animatorC.GetBehaviour<Desarmado_SMBH>().RMB = RMB;




        animatorC.GetBehaviour<Desarmado_Salto_SMBH>().leftHorizontalInput = leftHorizontalInput;
        animatorC.GetBehaviour<Desarmado_Salto_SMBH>().leftVerticalInput = leftVerticalInput;


        animatorC.GetBehaviour<Armado_Rodar_SMBH>().leftHorizontalInput = leftHorizontalInput;
        animatorC.GetBehaviour<Armado_Rodar_SMBH>().leftVerticalInput = leftVerticalInput;

        animatorC.GetBehaviour<Armado_SMBH>().leftHorizontalInput = leftHorizontalInput;
        animatorC.GetBehaviour<Armado_SMBH>().leftVerticalInput = leftVerticalInput;
        animatorC.GetBehaviour<Armado_SMBH>().rightHorizontalInput = rightHorizontalInput;
        animatorC.GetBehaviour<Armado_SMBH>().rightVerticalInput = rightVerticalInput;
        animatorC.GetBehaviour<Armado_SMBH>().lShift = lShift;
        animatorC.GetBehaviour<Armado_SMBH>().btnC = btnC;
        animatorC.GetBehaviour<Armado_SMBH>().btnEspacio = btnEspacio;

        animatorC.GetBehaviour<Armado_SMBH>().LMB = LMB;

        animatorC.GetBehaviour<Armado_SMBH>().RMB = RMB;



        //animatorC.GetBehaviour<Desarmado_Salto_SMBH>().rightHorizontalInput = rightHorizontalInput;
        //animatorC.GetBehaviour<Desarmado_Salto_SMBH>().rightVerticalInput = rightVerticalInput;


        /* animatorC.GetBehaviour<Correr_Desarmado_SMBH>().leftHorizontalInput = leftHorizontalInput;
         animatorC.GetBehaviour<Correr_Desarmado_SMBH>().leftVerticalInput = leftVerticalInput;
         animatorC.GetBehaviour<Correr_Desarmado_SMBH>().rightHorizontalInput = rightHorizontalInput;
         animatorC.GetBehaviour<Correr_Desarmado_SMBH>().rightVerticalInput = rightVerticalInput;
         animatorC.GetBehaviour<Correr_Desarmado_SMBH>().lShift = lShift;
         animatorC.GetBehaviour<Correr_Desarmado_SMBH>().btnC = btnC;


         animatorC.GetBehaviour<Andar_Desarmado_SMBH>().leftHorizontalInput = leftHorizontalInput;
         animatorC.GetBehaviour<Andar_Desarmado_SMBH>().leftVerticalInput = leftVerticalInput;
         animatorC.GetBehaviour<Andar_Desarmado_SMBH>().rightHorizontalInput = rightHorizontalInput;
         animatorC.GetBehaviour<Andar_Desarmado_SMBH>().rightVerticalInput = rightVerticalInput;
         animatorC.GetBehaviour<Andar_Desarmado_SMBH>().lShift = lShift;
         animatorC.GetBehaviour<Andar_Desarmado_SMBH>().btnC = btnC;


         animatorC.GetBehaviour<Agachado_SMBH>().leftHorizontalInput = leftHorizontalInput;
         animatorC.GetBehaviour<Agachado_SMBH>().leftVerticalInput = leftVerticalInput;
         animatorC.GetBehaviour<Agachado_SMBH>().rightHorizontalInput = rightHorizontalInput;
         animatorC.GetBehaviour<Agachado_SMBH>().rightVerticalInput = rightVerticalInput;
         animatorC.GetBehaviour<Agachado_SMBH>().lShift = lShift;
         animatorC.GetBehaviour<Agachado_SMBH>().btnC = btnC;
         */

        //   if (a.IsName("Correr"))
        //   {


        /*   animatorC.GetBehaviour<Correr_Desarmado_SMBH>().leftHorizontalInput = leftHorizontalInput;
           animatorC.GetBehaviour<Correr_Desarmado_SMBH>().leftVerticalInput = leftVerticalInput;
           animatorC.GetBehaviour<Correr_Desarmado_SMBH>().rightHorizontalInput = rightHorizontalInput;
           animatorC.GetBehaviour<Correr_Desarmado_SMBH>().rightVerticalInput = rightVerticalInput;


           animatorC.GetBehaviour<Andar_Desarmado_SMBH>().leftHorizontalInput = leftHorizontalInput;
           animatorC.GetBehaviour<Andar_Desarmado_SMBH>().leftVerticalInput = leftVerticalInput;
           animatorC.GetBehaviour<Andar_Desarmado_SMBH>().rightHorizontalInput = rightHorizontalInput;
           animatorC.GetBehaviour<Andar_Desarmado_SMBH>().rightVerticalInput = rightVerticalInput;


           GetComponent<Animator>().SetBool("shift", lShift);
           */


        //   }
        //   else if (a.IsName("Andar"))
        //   {
        //      Debug.Log("ANDARS");


        /* animatorC.GetBehaviour<Andar_Desarmado_SMBH>().leftHorizontalInput = leftHorizontalInput;
         animatorC.GetBehaviour<Andar_Desarmado_SMBH>().leftVerticalInput = leftVerticalInput;
         animatorC.GetBehaviour<Andar_Desarmado_SMBH>().rightHorizontalInput = rightHorizontalInput;
         animatorC.GetBehaviour<Andar_Desarmado_SMBH>().rightVerticalInput = rightVerticalInput;

         GetComponent<Animator>().SetBool("shift", lShift);
         */
        //    }


        //  StateMachineBehaviour correr = GetComponent<Animator>().GetBehaviour<Correr_Desarmado_SMBH>();

    }


    public bool GetVariablesFromBH(string nV)
    {
        bool rt = false;
        if (nV == "apuntandoArco")
        {
            AnimatorStateInfo b = animatorC.GetCurrentAnimatorStateInfo(1);

            if (b.IsName("Apuntar"))
            {
                rt = true;
            }

        } else
        {

      
        AnimatorStateInfo a = animatorC.GetCurrentAnimatorStateInfo(0);
        if (a.IsName("Correr") || a.IsName("Agacharse") || a.IsName("Agachado") || a.IsName("Levantarse") || a.IsName("Andar") || a.IsName("Saltar"))
        {
            switch (nV)
            {
                case "JD":
                    rt = animatorC.GetBehaviour<Desarmado_SMBH>().JD;

                    break;

                case "JI":
                    rt = animatorC.GetBehaviour<Desarmado_SMBH>().JI;


                    break;


                case "blockJI":
                    rt = animatorC.GetBehaviour<Desarmado_SMBH>().blockJI;

                    break;

            }


        }
        if (a.IsName("Andar_Armado") || a.IsName("Rodar_Armado"))
        {
            switch (nV)
            {
                case "JD":

              //      Debug.Log(animatorC.GetBehaviour<Armado_SMBH>().JD);
                    rt = animatorC.GetBehaviour<Armado_SMBH>().JD;

                    break;

                case "JI":
                    rt = animatorC.GetBehaviour<Armado_SMBH>().JI;


                    break;


                case "blockJI":
                    rt = animatorC.GetBehaviour<Armado_SMBH>().blockJI;

                    break;

            }

            }
        }
        return rt;
        
    }

    public void TiempoComboOn()
    {
        Debug.Log("ESPEROCOMBOOO");

        GameObject.Find("ybot").GetComponent<Animator>().SetBool("comboAcertado", false);

        StartCoroutine(Combo());

    }
    IEnumerator Combo()
    {
        float t = Time.time;

        while (t+0.2f > Time.time)
        {
            yield return new WaitForFixedUpdate();
            if (LMB)
            {

                GameObject.Find("ybot").GetComponent<Animator>().SetBool("comboAcertado", true);
            }
        }

    }

  
    /*public void GirarPlayer(float f)
    {

        StartCoroutine(GPlayer(f));
    }

    IEnumerator GPlayer(float f)
    {


        yield return new WaitForEndOfFrame();
        transform.Rotate(0, f, 0);


    }
    /* public void IniCor(IEnumerator a)
     {
         StartCoroutine(a);

     }
     public void StopCor(IEnumerator a)
     {
         StopCoroutine(a);
         VariablesJD("coroutineJD");

     }
     public IEnumerator GetCor()
     {
         return DerechoJoystickRetarded();

     }
     IEnumerator DerechoJoystickRetarded()
     {
         VariablesJD("JD");
         float t = Time.time;
         //     Debug.Log("RETARDOO");
         yield return new WaitForSeconds(2);
         //    Debug.Log("FIN RETARDO"+ (Time.time-t));


         //   JD= false;
         VariablesJD("coroutineJD");

     }
     public void VariablesJD(string v)
     {

         AnimatorStateInfo a = animatorC.GetCurrentAnimatorStateInfo(0);
         if (a.IsName("Correr"))
         {
             switch (v)
             {
                 case "JD":
                     animatorC.GetBehaviour<Correr_Desarmado_SMBH>().JD = true;

                     break;

                 case "coroutineJD":
                     animatorC.GetBehaviour<Correr_Desarmado_SMBH>().coroutineJD  = null;
                     break;


             }

         }
         else if (a.IsName("Andar"))
         {
             switch (v)
             {
                 case "JD":
                     animatorC.GetBehaviour<Andar_Desarmado_SMBH>().JD = true;

                     break;

                 case "coroutineJD":
                     animatorC.GetBehaviour<Andar_Desarmado_SMBH>().coroutineJD = null;
                     break;

             }
         }


     }*/
}