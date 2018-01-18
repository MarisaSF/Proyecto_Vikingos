using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    CharaManager cmScript;



    //   public bool JD = false;
    //  public bool JI = false;


    // Use this for initialization
    void Start()
    {

        cmScript = GetComponent<CharaManager>();
    }

    // Update is called once per frame
    void Update()
    {

        /*   ccScript.leftHorizontalInput = Input.GetAxis("Horizontal");
           ccScript.leftVerticalInput = Input.GetAxis("Vertical");
           ccScript.rightHorizontalInput = Input.GetAxis("Mouse X");
           ccScript.rightVerticalInput = Input.GetAxis("Mouse Y");*/

        cmScript.leftHorizontalInput = Input.GetAxis("Horizontal");
        cmScript.leftVerticalInput = Input.GetAxis("Vertical");
        cmScript.rightHorizontalInput = Input.GetAxis("Mouse X");
        cmScript.rightVerticalInput = Input.GetAxis("Mouse Y");

        cmScript.lShift = (Input.GetAxis("Fire3") == 1) ? true : false;
        //    Debug.Log(Input.GetAxis("Fire3"));

        GameObject.Find("Pivote_Camara_Y").GetComponent<Rotacion_Camara_Y>().inputMouseX = Input.GetAxis("Mouse X");
        GameObject.Find("Pivote_Camara_X").GetComponent<Rotacion_Camara_X>().inputMouseY = Input.GetAxis("Mouse Y");




    }


}
