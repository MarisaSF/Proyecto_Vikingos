using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour {
    Transform player;
    Rigidbody rb;
    //Vector3 posicion;
    Vector3 direction;
    Color white=Color.white;
    public Transform cuerpo;

    // Use this for initialization
    void Start() {
        this.transform.SetParent(null); 
        this.gameObject.GetComponent<Animation>().enabled = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        cuerpo = player.Find("punto").GetComponent<Transform>();
        //posicion = player.position;
        rb = this.gameObject.GetComponent<Rigidbody>();
        transform.LookAt(cuerpo.position);
        direction = rb.transform.position - cuerpo.transform.position;
        //direction += new Vector3(0, 1.7f, 0);
        //rb.AddForceAtPosition(transform.position, direction.normalized,  ForceMode.Impulse);
        rb.AddForce(transform.forward * 3, ForceMode.Impulse);
        //rb.AddForce(transform.forward, ForceMode.Force);
        white.a = 0;
        Destroy(this.gameObject,10f);
    }

    // Update is called once per frame
    void Update() {
        

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("colisiona flecha");
        if (other.tag == "Player")
        {
            Debug.Log("Colisiona flecha con player");
            rb.isKinematic = true;
            transform.parent = other.transform;
            other.SendMessage("SiendoGolpeado", 10f); //NOTE Pablo function.
        }
        else
        {
            rb.isKinematic = true;
            this.transform.parent = other.gameObject.transform;
        }
        StartCoroutine("adios");
    }
    IEnumerator adios(){

        this.gameObject.transform.Find("trail").GetComponent<TrailRenderer>().enabled = false;
        this.gameObject.GetComponent<Animation>().enabled = true;
        //this.gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(this.gameObject.GetComponent<Material>().color,white, Mathf.PingPong(Time.time, 1));
        yield return new WaitForSeconds (2f);
        Destroy(this.gameObject);
}
}
