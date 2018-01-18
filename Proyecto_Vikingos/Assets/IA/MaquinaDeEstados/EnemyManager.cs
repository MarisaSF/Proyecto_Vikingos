using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    [Header("Patrol Settings")]
    public Transform[] puntos;
     bool PatrullaActiva=false;
    [Header("Live Settings")]
    public float vida = 100;
    Animator anim;
    [Header("Speed Settings")]
    public float VelCorrer;
    public float VelAndar;
   
    ControladorVision controlvision;

   public Transform target;
    /// <summary>
    /// Distancia a la que tiene que parar el enemigo cuando se acerque a jugador
    /// </summary>
    [Header("Distance Settings")]
    public float Distance = 2f;
    public float MaxDistanceArcher;
    public float RangoDeDaño = 3f;
    [Header("No Tocar")]
    public int ID;
    public float Daño;
    public bool modoataque = false;
    public float TimerArcherState; // no tocar
    public float MaxTimerArcherState;
    public GameObject Arrow;
     bool muerto = true;
    bool una = false;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        controlvision = GetComponent<ControladorVision>();
        target = GameObject.FindWithTag("Player").transform;
        MaxTimerArcherState = Random.Range(6, 12);

	}
	
	// Update is called once per frame
	void Update () {
        if ((puntos.Length > 1)&&(PatrullaActiva ==false))
        {
            PatrullaActiva = true;
            anim.SetTrigger("run");
        }
        if (vida <= 0) { muerto = false; }
        if ((vida <= 0) && (muerto == false) && (una == false))
        {
            Debug.Log("muerto");
            muerto = false;
            anim.SetBool("Muertobool", true);
            anim.SetTrigger("Muerto");
            una = true;
        }
	}
    // para que pablo pueda hacer daño al Player
    public void golpeo(float daño)                  
    {
       
        if (muerto == true)
        {
            Debug.Log("`Me Golpean");
            if ((modoataque == true) && (ID == 2))
            {
                //lanza un raycast y si tiene delante al jugador y ran no es 1
                int ran = Random.Range(1, 4);
                Debug.Log("Variable Random es: " + ran);
                if (ran == 1)
                {

                    vida -= daño;
                    anim.SetTrigger("golpeado");
                }
                else
                {
                    // ejecuta animacion parar
                    anim.SetTrigger("PararGolpe");
                }
            }
            else
            {
                vida -= daño;
                anim.SetTrigger("golpeado");
            }
        }
    }
   
    //Eventos de Animacion
    #region AnimationEvents
        public void Flechazo()
    {
        Instantiate(Arrow,this.gameObject.transform.Find("punto").transform.position,Quaternion.identity);
    }
    public void EnemyAttack()
    {
        Debug.Log("Ejecuta Enemy Attack");
        Vector3 targetDir = target.position - transform.position;
        float angle = Vector3.Angle(targetDir, transform.forward);
          float calculo= Vector3.Distance(target.position, transform.position);
          if ((angle < 60.0f) && (calculo < RangoDeDaño))
        {
            target.gameObject.SendMessage("SiendoGolpeado", Daño);
            Debug.Log("Ha echo daño al player");
        }
    }
    //Elimina el gameobject tras 2 segundos
    public void desapa()
    {
        removerlistPlayer();
        Debug.Log("Desaparece ");
       // anim.speed = 0;
        Destroy(this.gameObject, 2f);
    }
    public void añadirlistPlayer()
    {
        GameObject.FindObjectOfType<CharaController>().EnemigoEntraEnCombate(this.gameObject);
    }
    public void removerlistPlayer()
    {
        GameObject.FindObjectOfType<CharaController>().EnemigoSaleDeCombate(this.gameObject);
    }

    #endregion


}
