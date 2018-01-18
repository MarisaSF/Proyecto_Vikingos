using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaManager : MonoBehaviour
{


    Animator animatorC;



    public float leftHorizontalInput;
    public float leftVerticalInput;
    public float rightHorizontalInput;
    public float rightVerticalInput;

    public bool JD = false;
    public bool JI = false;
    public bool blockJI = false;


    public bool lShift = false;

    // Use this for initialization
    void Start()
    {

        animatorC = GetComponent<Animator>();

    }


    // Update is called once per frame
    void Update()
    {

        AnimatorStateInfo a = animatorC.GetCurrentAnimatorStateInfo(0);


        animatorC.GetBehaviour<Correr_Desarmado_SMBH>().leftHorizontalInput = leftHorizontalInput;
        animatorC.GetBehaviour<Correr_Desarmado_SMBH>().leftVerticalInput = leftVerticalInput;
        animatorC.GetBehaviour<Correr_Desarmado_SMBH>().rightHorizontalInput = rightHorizontalInput;
        animatorC.GetBehaviour<Correr_Desarmado_SMBH>().rightVerticalInput = rightVerticalInput;
        animatorC.GetBehaviour<Correr_Desarmado_SMBH>().lShift = lShift;


        animatorC.GetBehaviour<Andar_Desarmado_SMBH>().leftHorizontalInput = leftHorizontalInput;
        animatorC.GetBehaviour<Andar_Desarmado_SMBH>().leftVerticalInput = leftVerticalInput;
        animatorC.GetBehaviour<Andar_Desarmado_SMBH>().rightHorizontalInput = rightHorizontalInput;
        animatorC.GetBehaviour<Andar_Desarmado_SMBH>().rightVerticalInput = rightVerticalInput;
        animatorC.GetBehaviour<Andar_Desarmado_SMBH>().lShift = lShift;


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

        AnimatorStateInfo a = animatorC.GetCurrentAnimatorStateInfo(0);
        if (a.IsName("Correr"))
        {
            switch (nV)
            {
                case "JD":
                    rt = animatorC.GetBehaviour<Correr_Desarmado_SMBH>().JD;

                    break;

                case "JI":
                    rt = animatorC.GetBehaviour<Correr_Desarmado_SMBH>().JI;


                    break;


                case "blockJI":
                    rt = animatorC.GetBehaviour<Correr_Desarmado_SMBH>().blockJI;

                    break;
            }

        }
        else if (a.IsName("Andar"))
        {
            switch (nV)
            {
                case "JD":
                    rt = animatorC.GetBehaviour<Andar_Desarmado_SMBH>().JD;

                    break;

                case "JI":
                    rt = animatorC.GetBehaviour<Andar_Desarmado_SMBH>().JI;


                    break;


                case "blockJI":
                    rt = animatorC.GetBehaviour<Andar_Desarmado_SMBH>().blockJI;

                    break;
            }
        }

        return rt;

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