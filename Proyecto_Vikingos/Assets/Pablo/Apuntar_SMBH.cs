using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apuntar_SMBH : StateMachineBehaviour {

    float t;

    float elTiempo;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        t = Time.time;
        GameObject.Find("ybot").GetComponent<CharaManager>().puntoDeMira.SetActive(true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        elTiempo = Time.time - t;
        GameObject.Find("ybot").GetComponent<CharaManager>().puntoDeMira.transform.Find("Carga").GetComponent<UnityEngine.UI.Image>().fillAmount+= 0.01f;

        if (GameObject.Find("Main Camera").transform.localPosition.z < -0.8f)
        {
            GameObject.Find("Main Camera").transform.localPosition += new Vector3(0, 0, 0.1f);

        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject.Find("ybot").GetComponent<CharaManager>().puntoDeMira.SetActive(false);

        GameObject.Find("Main Camera").transform.localPosition = new Vector3(0.75f, 0.7f, -2.9f);
        Debug.Log("TIEMPO PULSADO: " + (Time.time - t));

        GameObject f = Instantiate(Resources.Load("Flecha")) as GameObject;

        //   Vector3 posPlayer = GameObject.Find("ybot").transform.InverseTransformPoint()

        f.transform.position = GameObject.Find("ybot").transform.position +(Vector3.up*1.5f)+ GameObject.Find("ybot").transform.forward*1.2f;


       // f.transform.eulerAngles += new Vector3(GameObject.Find("Pivote_Camara_X").transform.eulerAngles.x, GameObject.Find("Pivote_Camara_Y").transform.eulerAngles.y + 90, 0);

        f.transform.eulerAngles += new Vector3(0, GameObject.Find("Pivote_Camara_Y").transform.eulerAngles.y+95, GameObject.Find("Pivote_Camara_X").transform.eulerAngles.x-6);
        //    f.transform.rotation = GameObject.Find("ybot").transform.rotation;



        float fA = GameObject.Find("ybot").GetComponent<CharaManager>().puntoDeMira.transform.Find("Carga").GetComponent<UnityEngine.UI.Image>().fillAmount;


        f.GetComponent<Rigidbody>().AddForce(-f.transform.up *fA* 25,ForceMode.Impulse);
        GameObject.Find("ybot").GetComponent<CharaManager>().puntoDeMira.transform.Find("Carga").GetComponent<UnityEngine.UI.Image>().fillAmount = 0;
       // UnityEditor.EditorApplication.isPaused = true;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
