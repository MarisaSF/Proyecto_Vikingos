using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    CharaController ccScript;

    Rotacion_Camara_X rotXScript;
    Rotacion_Camara_Y rotYScript;

    //   public bool JD = false;
    //  public bool JI = false;


    // Use this for initialization
    void Start()
    {

        ccScript = GetComponent<CharaController>();
        rotYScript = GameObject.Find("Pivote_Camara_Y").GetComponent<Rotacion_Camara_Y>();
        rotXScript = GameObject.Find("Pivote_Camara_X").GetComponent<Rotacion_Camara_X>();

    }

    // Update is called once per frame
    void Update()
    {


        ccScript.leftHorizontalInput = Input.GetAxis("Horizontal");
        ccScript.leftVerticalInput = Input.GetAxis("Vertical");
        ccScript.rightHorizontalInput = Input.GetAxis("Mouse X");
        ccScript.rightVerticalInput = Input.GetAxis("Mouse Y");

       
        ccScript.leftRawHorizontalInput = Input.GetAxisRaw("Horizontal");
        ccScript.leftRawVerticalInput = Input.GetAxisRaw("Vertical");

        ccScript.lShift = (Input.GetAxis("Fire3") == 1) ? true : false;

        ccScript.btnEspacio = (Input.GetAxis("Jump") == 1) ? true : false;



        ccScript.LMB = Input.GetMouseButton(0);
        ccScript.RMB = Input.GetMouseButton(1);

        ccScript.btnCPulsado = Input.GetKeyDown(KeyCode.C);

    /*    if (Input.GetKeyDown(KeyCode.C))
        {
            ccScript.btnC = !ccScript.btnC;

        }else if(ccScript.gameObject.GetComponent<Animator>().GetBool("espacio"))
        {

            ccScript.btnC = false;
        }*/



        rotYScript.inputMouseX = Input.GetAxis("Mouse X");
        rotXScript.inputMouseY = Input.GetAxis("Mouse Y");




    }


}
