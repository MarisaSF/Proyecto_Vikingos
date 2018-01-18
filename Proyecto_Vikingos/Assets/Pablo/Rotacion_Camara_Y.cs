using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion_Camara_Y : MonoBehaviour
{

    float rot_Speed_Y = 1;
    public float gradosY = 0;
    float gradosMAX = 90;
    float gradosMIN = -90;


    public float inputMouseX;
    public CharaController ccScript;

    void Start()
    {
        ccScript = GameObject.Find("ybot").GetComponent<CharaController>();
    }

    void Update()
    {

        if (ccScript.JD && Time.timeScale != 0)
        {

            transform.Rotate(0, inputMouseX, 0);

        }

       /* if (ccScript.GetVariablesFromBH("apuntandoArco"))
        {
            ccScript.transform.Rotate(0, inputMouseX, 0);

        }*/
    }
}
