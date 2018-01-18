using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EsceneChanger : MonoBehaviour {
    /// <summary>
    /// Cambio de escena
    /// </summary>
    public string Nombre; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene("Nombre", LoadSceneMode.Single);
        }
    }
}
