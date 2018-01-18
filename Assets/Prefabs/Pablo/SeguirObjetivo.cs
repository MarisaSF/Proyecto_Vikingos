using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirObjetivo : MonoBehaviour
{

    public Transform target;
    float smoothPosition = 2;
    float smoothRotation = 4;

    GameObject camara;
    GameObject player;

    public LayerMask miMascaraDeCapas;

    void Start()
    {

        camara = GameObject.Find("Main Camera");
        player = GameObject.Find("ybot");

    }
    // Update is called once per frame
    void Update()
    {




        transform.position = Vector3.Lerp(transform.position, target.position + new Vector3(0, 1, 0), Time.deltaTime * smoothPosition);

        if ((player.GetComponent<CharaManager>().GetVariablesFromBH("JD") && !player.GetComponent<CharaManager>().GetVariablesFromBH("JI")) || player.GetComponent<CharaManager>().GetVariablesFromBH("blockJI"))
        {
        }
        else
        {
            //Debug.Log("eeeeee");

            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * smoothRotation);

            //TO DO SOLO SIGUE EN EL EJE Y
            //  transform.Find("Pivote_Camara_X").rotation = Quaternion.Lerp(transform.Find("Pivote_Camara_X").rotation, target.rotation, Time.deltaTime * smoothRotation);


        }


        /*    Vector3 niumi = player.transform.position + new Vector3(0, 1, 0);
            Debug.DrawLine(camara.transform.position, niumi, Color.magenta);
            RaycastHit wallHit = new RaycastHit();
            if (Physics.Linecast(camara.transform.position, niumi, out wallHit, miMascaraDeCapas))
            {
                Debug.Log(wallHit.transform.name);
                Debug.DrawRay(wallHit.point, Vector3.left, Color.red);



            }
            */


    }



}
