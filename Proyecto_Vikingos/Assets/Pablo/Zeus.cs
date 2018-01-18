using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zeus : MonoBehaviour
{
    public LayerMask miMascara;
    public GameObject escalera;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        RaycastHit hit;
        //     Vector3 forward = transform.TransformDirection(Vector3.forward) * 1.5f;

        Debug.DrawRay(transform.position + new Vector3(0, 1f, 0), transform.forward * 1.5f, Color.green);
        //    Physics.Raycast()

        if (Physics.Raycast(transform.position + new Vector3(0, 1f, 0), transform.TransformDirection(Vector3.forward), out hit, 1.5f, miMascara)) //Si detecta una escalera la guarda

        {

            //     Debug.Log(hit.collider.gameObject.name);

            escalera = hit.collider.gameObject;
            escalera.GetComponent<EscaleraKK>().enabled = true;
            escalera.GetComponent<EscaleraKK>().Activando();
        } /*else if(!GetComponent<Animator>().GetBool("escalera")) //Solo olvida la escalera si no está detectando ninguna y si el pj no está en modo escalera
        {


            escalera = null;
        }*/
          /*  RaycastHit hit2;
            //     Vector3 forward = transform.TransformDirection(Vector3.forward) * 1.5f;

            Debug.DrawRay(transform.position + new Vector3(0, +0.1f, 0), -transform.up * 10f, Color.magenta);
            //    Physics.Raycast()

            if (Physics.Raycast(transform.position+ new Vector3(0,+0.1f,0), transform.TransformDirection(-Vector3.up), out hit2, 10f)) 
            {

                //      Debug.Log(hit2.collider.gameObject.name);

                if (hit2.distance > 1.0f)
                {
                    Debug.Log(hit2.distance);

                    GetComponent<CharacterController>().Move(new Vector3(0, -1 * Time.deltaTime, 0));


                }


            } /*else if(!GetComponent<Animator>().GetBool("escalera")) //Solo olvida la escalera si no está detectando ninguna y si el pj no está en modo escalera
            {



        }*/


    }
}
