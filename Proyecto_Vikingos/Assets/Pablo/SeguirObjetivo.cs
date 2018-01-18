using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirObjetivo : MonoBehaviour
{

    public Transform target;
    float smoothPosition = 4;
    float smoothRotation = 4;

    GameObject camara;
    GameObject player;
    CharaController ccScript;
    public LayerMask miMascaraDeCapas;

    void Start()
    {
        ccScript = GameObject.Find("ybot").GetComponent<CharaController>();
        camara = GameObject.Find("Main Camera");
        player = GameObject.Find("ybot");
        camara.transform.localPosition = new Vector3(0.75f, 0.7f, -2.9f);
    }
    // Update is called once per frame
    void Update()
    {

        transform.position = Vector3.Lerp(transform.position, target.position + new Vector3(0, 1, 0), Time.deltaTime * smoothPosition);

        if (((ccScript.JD && !ccScript.JI) || ccScript.blockJI))
        {
        }
        else
        {

            transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, Time.deltaTime * smoothRotation);

       

        }


    }



}
