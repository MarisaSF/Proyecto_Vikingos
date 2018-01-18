using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Navmesh : MonoBehaviour {
    NavMeshAgent agente;
   public Transform[] recorrido;
    float temp;
    bool go = false;
   public int point;
   public desmontar[] desmont;
	// Use this for initialization
    void Awake()
    {
        agente = this.gameObject.GetComponent<NavMeshAgent>();
    }
	void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
        if (go == true)
        {
           
            agente.SetDestination(recorrido[point].position);
            agente.speed = 1;
           
            if ((agente.remainingDistance <= agente.stoppingDistance) && !agente.pathPending)
            {
                Debug.Log("He llegado");
                agente.Stop();
                temp += Time.deltaTime;
                if (temp > 9f)
                {
                    desmont[point].enabled = true;
                }

                if (temp > 10f)
                {
                    Debug.Log("Tiempo");
                    if (point == recorrido.Length)
                    {
                        agente.Stop();
                    }
                    else
                    {
                        Debug.Log("Suma");

                        point++;

                        if (point == recorrido.Length)
                        {
                            point = recorrido.Length;
                            go = false;
                        }

                        agente.isStopped = false;
                        // agente.SetDestination(recorrido[point].position);
                        temp = 0;
                    }
                }
            }

        }
	}
    void OnTriggerStay(Collider other) {
        if (other.tag == "Player")
        {
            if (Input.GetKey(KeyCode.E))
            {
                go = true;
            }
        }
    }

}
