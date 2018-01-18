using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscaleraKK : MonoBehaviour
{
    public Transform obj;

    public Vector3 ini;

    bool prep = true;

    
   void OnEnable()
    {

    }
  public  void Activando()
    {


        Debug.Log("ASLASLKJ");
        ini = GameObject.Find("ybot").transform.position;
        GameObject.Find("ybot").GetComponent<Animator>().SetBool("escalando", true);
       // StartCoroutine(Preparando());

    }
  /*  IEnumerator Preparando()
    {
        bool rot = false;
        bool pos = false;

        while (!rot || !pos)
        {
            if (!rot)
            {
                
                GameObject.Find("ybot").transform.rotation = Quaternion.Lerp(GameObject.Find("ybot").transform.rotation, transform.rotation, Time.deltaTime * 3);
              
                Debug.Log(" dasd"+ Quaternion.Angle(GameObject.Find("ybot").transform.rotation, transform.rotation));
                if (Quaternion.Angle(GameObject.Find("ybot").transform.rotation, transform.rotation) < 0.1f)
                {
                    rot = true;
                }

            }

            if (!pos)
            {
                GameObject.Find("ybot").transform.position = Vector3.Lerp(GameObject.Find("ybot").transform.position, transform.position + new Vector3(0, -transform.position.y, -1f), Time.deltaTime * 3);

                if (Vector3.Distance(GameObject.Find("ybot").transform.position, transform.position + new Vector3(0, -transform.position.y, -1f))< 0.1f)
                {
                    pos = true;
                }
            }

            yield return new WaitForSeconds(0.2f);
        }
        prep = true;


    }*/
    void Update()
    {
        if (prep)
        {

      
        if (Mathf.Abs(GameObject.Find("ybot").transform.position.y + 1.8f - obj.position.y-1f) < 0.5f)
        {
            Debug.Log("arriba");

            GameObject.Find("ybot").GetComponent<Animator>().SetBool("escalando", false);

            this.enabled = false;
        }
            /* else if (Mathf.Abs(GameObject.Find("ybot").transform.position.y - ini.y) < 0.5f && GameObject.Find("ybot").GetComponent<CharaController>().leftHorizontalInput == -1)
             {
                 Debug.Log("abajo");
                 GameObject.Find("ybot").GetComponent<Animator>().SetBool("escalando", false);
                 GameObject.Find("ybot").GetComponent<Animator>().SetTrigger("escalandoAbajo");

                 this.enabled = false;

             }*/
        }


    }
    public void Escale()
    {

        GameObject.Find("ybot").transform.position = obj.position + new Vector3(0, 2, 0);



    }
}
