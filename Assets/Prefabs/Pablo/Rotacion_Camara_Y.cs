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

    // Update is called once per frame
    void Update()
    {

        //  Debug.Log(Input.GetAxis("Mouse X") + "   " + Input.GetAxis("Mouse Y"));

        //   gradosY += inputMouseX * rot_Speed_Y;
        //       gradosY = Mathf.Clamp(gradosY, gradosMIN, gradosMAX);
        //  transform.localEulerAngles = new Vector3(0, gradosY, 0);


        if (GameObject.Find("ybot").GetComponent<CharaManager>().GetVariablesFromBH("JD"))
        {

            transform.Rotate(0, inputMouseX, 0);

        }
    }
}
