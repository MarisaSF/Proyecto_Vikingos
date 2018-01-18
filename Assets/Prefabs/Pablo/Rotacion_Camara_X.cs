using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion_Camara_X : MonoBehaviour
{


    float rot_Speed_X = -1;
    public float gradosX = 0;
    public float gradosMAX = 90;
    public float gradosMIN = -90;
    public float inputMouseY;

    float rotCalculada = 0;
    // Update is called once per frame
    void Update()
    {



        /*  gradosX += inputMouseY * rot_Speed_X;
          gradosX = Mathf.Clamp(gradosX, gradosMIN, gradosMAX);
          transform.localEulerAngles = new Vector3(gradosX, 0, 0);
          */

        if (GameObject.Find("ybot").GetComponent<CharaManager>().GetVariablesFromBH("JD"))
        {
            if ((Mathf.Sign(inputMouseY) == 1 && rotCalculada < 50) || (Mathf.Sign(inputMouseY) == -1 && rotCalculada > -50))
            {
                rotCalculada += inputMouseY;
                transform.Rotate(inputMouseY, 0, 0);
                //      Debug.Log(rotCalculada);
            }


        }
    }
}
