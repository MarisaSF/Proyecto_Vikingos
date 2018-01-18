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

    public CharaController ccScript;

    void Start()
    {
        ccScript = GameObject.Find("ybot").GetComponent<CharaController>();

    }
    // Update is called once per frame
    void Update()
    {
        inputMouseY *= -1;
        if (ccScript.JD && Time.timeScale != 0)
        {
            if ((Mathf.Sign(inputMouseY) ==1 && rotCalculada < 50) || (Mathf.Sign(inputMouseY) == -1 && rotCalculada > -50))
            {
                rotCalculada += inputMouseY;
                transform.Rotate(inputMouseY, 0, 0);
            }
          

        }
    }
}
