using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evento2 : MonoBehaviour {
   public Rigidbody[] explosion;
    bool una = false;
    public GameObject cam1;
    public GameObject cam2;
    EnemyManager manager;
    // Use this for initialization
    void Start () {
        manager = this.GetComponent<EnemyManager>();
    }
	
	// Update is called once per frame
	void Update () {
        if (manager.vida <= 0) { una = true; manager = null; }
        if (una == true)
        {
            foreach (Rigidbody ri in explosion)
            {
                ri.isKinematic = false;
                ri.AddForce(transform.right * 4, ForceMode.Impulse);
            }
            una = false;

            StartCoroutine("camaras");
        }
    }
  
    IEnumerator camaras()
    {
        cam1.SetActive(false);
        cam2.SetActive(true);
        yield return new WaitForSeconds(2f);
        cam1.SetActive(true);
        cam2.SetActive(false);
    }
}
