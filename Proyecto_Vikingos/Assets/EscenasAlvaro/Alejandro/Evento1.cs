using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento1 : MonoBehaviour {
    public GameObject subject;
    public GameObject subject1;
    public GameObject Director;

    // Quaternion lerp;
    // Use this for initialization
    void Start() {
        //  lerp = new Quaternion(-90, 180, 0, 0);
    }

    // Update is called once per frame
    void Update() {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("entr");
            Director.SetActive(true);
            StartCoroutine("corutina");
        }

    }
    IEnumerator corutina()
    {
        yield return new WaitForSeconds(7f);
        Destroy(subject1);
        yield return new WaitForSeconds(3f);
        Destroy(subject);
    }
        

}
