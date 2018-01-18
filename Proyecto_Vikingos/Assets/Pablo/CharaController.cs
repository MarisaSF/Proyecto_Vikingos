using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : MonoBehaviour
{
    //TO DO
    //Cortar ataque al empezar el esquive
    //Mejorar transicion de la camara al salir y entrar en modo arco
    //Punteria del arco :S
    //Cambiar valores del capsule collider cuando se agacha
    //Sustituir animaciones chungas -, que salte más. Replantear el salto 
    //Es realmente necesario el CharacterController?
    //Camara con colisiones
    //Que reste la municion al soltar la flecha y que se pueda cancelar el disparo

    //Minimo de tension en el arco
    public float leftHorizontalInput;
    public float leftVerticalInput;
    public float rightHorizontalInput;
    public float rightVerticalInput;

    public float leftRawHorizontalInput;
    public float leftRawVerticalInput;


    public bool JD = false;
    public IEnumerator coroutineJD = null;
    public bool lastFrameJD = false;

    public bool JI = false;
    public bool blockJI = false;
    public bool lastFrameJI = false;




    public bool lShift = false;

    public bool btnCPulsado = false;
    public bool btnC = false;


    public bool btnEspacio = false;

    public bool LMB = false;
    public bool fuerzaLMB = false;
    public bool RMB = false;

    public bool golpeando = false;

    public bool combo = false;


    public bool saltando = false;


    public bool apuntando = false;
    public GameObject puntoDeMira;
    float tiempoIni = 0;
    float tiempoTenso = 0;

    Animator charAnimator;
    GameObject pivote_Y;
    GameObject pivote_X;
    GameObject camara;

    public GameObject hacha;
    public GameObject manoDer;
    public GameObject espalda;
    public GameObject arco;
    public GameObject manoIzq;
    Vector3 hachaPos;
    Vector3 arcoPos;
    Quaternion hachaRot;
    Quaternion arcoRot;

    bool salirPelea = false;
   public  List<GameObject> enemigosCombate = new List<GameObject>();
    RaycastHit hit;

    Inventario_Player inventario;

    [Header("TUTORIAL")]
    [Space(10)]
    [Tooltip("Bloquea el uso del arco")]
    public bool RMBBlock = false; //Tutorial Marisa ()
    [Tooltip("Bloquea el uso del hacha")]
    public bool LMBBlock = false; //Tutorial Marisa (Sacar hacha/pegar)
    [Tooltip("Bloquea el uso del salto")]
    public bool btnEspacioBlock = false; //Tutorial Marisa (Saltar)
    [Tooltip("Bloquea el agache")]
    public bool btnCBlock = false; //Tutorial Marisa (Agacharse)
    GameObject e;

    // Use this for initialization
    void Start()
    {
        inventario = GetComponent<Inventario_Player>();
        e = gameObject;
        hachaPos = hacha.transform.localPosition;
        arcoPos = arco.transform.localPosition;
        hachaRot = hacha.transform.localRotation;
        arcoRot = arco.transform.localRotation;
        charAnimator = GetComponent<Animator>();
        pivote_Y = GameObject.Find("Pivote_Camara_Y");
        pivote_X = GameObject.Find("Pivote_Camara_X");
        camara = GameObject.Find("Main Camera");
    }

    void Update()
    {
     
        if (fuerzaLMB)
        {
            LMB = true;
        }

        /*
         * 
         * Tutorial
         * 
         * */
        if (btnEspacioBlock)
        {
            btnEspacio = false;
        }
        if (LMBBlock)
        {
            LMB = false;
        }

        if (RMBBlock)
        {
            RMB = false;
        }
        if (btnCBlock)
        {
            btnCPulsado = false;
        }

        /*
         * 
         * ¿Esta en pelea?
         * 
         * */
        if (!charAnimator.GetCurrentAnimatorStateInfo(1).IsName("Desarmado")  && !salirPelea)
        {

            charAnimator.SetBool("enPelea", true);

        } else if(charAnimator.GetCurrentAnimatorStateInfo(1).IsName("Desarmado"))
        {
            salirPelea = false;
            charAnimator.SetBool("enPelea", false);

        }




        /*
        * Variables del animator
        * 
        * */
        charAnimator.SetFloat("vel_X", leftHorizontalInput, 0.2f, Time.deltaTime * 1);
        charAnimator.SetFloat("vel_Z", leftVerticalInput, 0.2f, Time.deltaTime * 1);
        charAnimator.SetBool("shift", lShift);


        if (!saltando && btnEspacio && charAnimator.GetBool("espacio") != btnEspacio)
        {
            charAnimator.SetFloat("salto_X", leftRawHorizontalInput);
            charAnimator.SetFloat("salto_Z", leftRawVerticalInput);
            StartCoroutine(EstoySaltando());
        }


        charAnimator.SetBool("espacio", btnEspacio);

        charAnimator.SetBool("LMB", LMB);
        charAnimator.SetBool("RMB", RMB);


        

        btnC = btnCPulsado ? !btnC : btnC;

        btnC = (btnEspacio) ? false : btnC;

        charAnimator.SetBool("agacharse", btnC);





        /*
         * Estado de los joysticks
         * 
         * */

        //El joystick izquierdo esta pulsado en este frame?
        JI = IzquierdoJoystick();


        if (coroutineJD == null) //Si no hay corrutina de retardoJD activa, toma el valor real de JD 
        {
            JD = DerechoJoystick(); //Esta pulsado el joystick derecho este frame?
        }

        if (!lastFrameJD && JD && DerechoJoystick() && coroutineJD != null) //Si acabo de pulsar JD y habia una corrutina activa, la para
        {

            StopCoroutine(coroutineJD);
            coroutineJD = null;

        }
        else if (lastFrameJD && !JD && coroutineJD == null) //Si he dejado de pulsar JD, activa la corrutina de retardo
        {

            coroutineJD = DerechoJoystickRetarded();
            StartCoroutine(coroutineJD);

        }



        /*
         * Logica de los joysticks
         * 
         * */


        if (!JD && JI) //Joystick derecho libre, joystick izquierdo en uso
        {

            transform.Rotate(0, leftHorizontalInput, 0); //El personaje rota con A, D

        }
        else if (JD && JI) //Joystick derecho en uso (o bloqueado), joystick izquierdo en uso
        {

            if (!lastFrameJI || blockJI) //Acabo de pulsar el joystick izquierdo o esta bloqueado
            {

                blockJI = true; //Se bloquea

                transform.rotation = Quaternion.Lerp(transform.rotation, pivote_Y.transform.rotation, Time.deltaTime * 6); //Se interpola la rotacion actual del personaje con la del eje horizontal de la camara

                float a = Vector3.Angle(transform.forward, pivote_Y.transform.forward);

                if (a < 1) //Si estan alineados se libera
                {
                    blockJI = false;

                }

            } //End if
            else if(!charAnimator.GetBool("escalando")) //?
            {

                transform.Rotate(0f, rightHorizontalInput, 0); //El personaje rota con el input horizontal del raton



            }



        }
         if (apuntando)
        {
            transform.Rotate(0, rightHorizontalInput, 0);

            tiempoTenso = Time.time - tiempoIni;
            puntoDeMira.transform.Find("Carga").GetComponent<UnityEngine.UI.Image>().fillAmount += 0.01f;
            if (camara.transform.localPosition.z < -0.8f)
            {
                camara.transform.localPosition += new Vector3(0, 0, 0.1f);

            }
            float a = Vector3.Angle(transform.forward, pivote_Y.transform.forward);

            if (a > 1) //Si estan alineados se libera
            {
                transform.rotation = Quaternion.Lerp(transform.rotation, pivote_Y.transform.rotation, Time.deltaTime * 6); //Se interpola la rotacion actual del personaje con la del eje horizontal de la camara

            }




            if (!RMB)
            {
                apuntando = false;
                camara.transform.localPosition = new Vector3(0.75f, 0.7f, -2.9f);

                GameObject f = Instantiate(Resources.Load("Flecha")) as GameObject;


                f.transform.position = transform.position + (Vector3.up * 1.5f) + transform.forward * 1.2f;



                f.transform.eulerAngles += new Vector3(0, pivote_Y.transform.eulerAngles.y + 95, pivote_X.transform.eulerAngles.x - 6);



                float fA = puntoDeMira.transform.Find("Carga").GetComponent<UnityEngine.UI.Image>().fillAmount;


                f.GetComponent<Rigidbody>().AddForce(-f.transform.up * fA * 25, ForceMode.Impulse);
                puntoDeMira.transform.Find("Carga").GetComponent<UnityEngine.UI.Image>().fillAmount = 0;
                puntoDeMira.SetActive(false);

            }
        }
        else if (charAnimator.GetCurrentAnimatorStateInfo(1).IsName("Apuntar") && RMB)
        {
            apuntando = true;
            puntoDeMira.SetActive(true);
            tiempoIni = Time.time;
        }

       /* if (!golpeando && 
            (charAnimator.GetCurrentAnimatorStateInfo(1).IsName("COMBO1") ||
            charAnimator.GetCurrentAnimatorStateInfo(1).IsName("COMBO2") || 
            charAnimator.GetCurrentAnimatorStateInfo(1).IsName("COMBO3")) &&
            )
        {

        }*/

        /*
         * Al final del frame guarda los valores para que se puedan comprobar en el siguiente
         * 
         * */

        lastFrameJI = IzquierdoJoystick();


        lastFrameJD = DerechoJoystick();

     //   if (GetComponent<CharacterController>().velocity.y > 0.1f || GetComponent<CharacterController>().velocity.y < -0.1f) 
      //  {
        //    Debug.Log(GetComponent<CharacterController>().velocity.y);

     //   }

        //GetComponent<CharacterController>().Move(new Vector3(0, -1.8f*Time.deltaTime, 0));
     //   Debug.Log(GetComponent<CharacterController>().isGrounded);
    }

   /* public void EmpiezaBatalla()
    {

        charAnimator.SetBool("enPelea", true);

        if (IsInvoking("TerminaBatalla"))
        {
            CancelInvoke("TerminarBatalla");
        }
        Invoke("TerminaBatalla", 3f);
        
    }*/

    public void TerminaBatalla()
    {
        bool todosNull = true;
        Debug.Log(enemigosCombate.Count);
        if (enemigosCombate.Count <= 0)
        {

            //Fin del combate
            charAnimator.SetBool("enPelea", false);
            salirPelea = true;
        } else
        {
            //TO DO ENEMIGOS ENTRAN MAS DE 1 VEZ

            foreach (var item in enemigosCombate)
            {
                if (item != null)
                {
                    todosNull = false;
                }
            }
            if (todosNull)
            {
                charAnimator.SetBool("enPelea", false);
                salirPelea = true;
            }


        }



    }
    public void SiendoGolpeado(float dmg)
    {
        
        Debug.Log("VIDA ANTES" + inventario.vidaRestante());
        inventario.restarVida(dmg);
        Debug.Log("VIDA ACTUAL " + inventario.vidaRestante()+" DESPUES DE QUITARLE "+dmg);

          inventario.restarVida(dmg);
          Debug.Log(inventario.vidaRestante()+"   LA VIDA"); //TO DO NO FUNCA FALTA INTEG DAVID
          if (inventario.vidaRestante() <= 0)
          {
              //MUERTO
              charAnimator.SetTrigger("muerto");

              charAnimator.SetLayerWeight(1, 0);

          }

    }


    public void ComprobarMunicion()
    {
        Debug.Log("MUNICION DISPONIBLE1" + inventario.municionDisponible());

        if (inventario.municionDisponible() <= 0) //TO DO NO FUNCA
        {
            charAnimator.SetTrigger("cancelarDisparo");
        }
        else
        {

            inventario.restarMunicion();

        }

        Debug.Log("MUNICION DISPONIBLE2" + inventario.municionDisponible());

    }
    public void dañarenemigo() // NOTE Funcion para dañar a enemigos de alex
    {
        Debug.Log("player ataca1");
        Debug.DrawRay(transform.position, transform.forward);
        if (Physics.Raycast(new Vector3(transform.position.x,transform.position.y+1,transform.position.z), transform.forward, out hit, 100.0f))
        {
            Debug.Log("player ataca2 " + hit.collider.name);
            if ((hit.distance < 3f) && (hit.collider.tag == "Enemy"))
            {

                hit.collider.gameObject.SendMessage("golpeo", 20f);
                Debug.Log("player ataca3"+hit.collider.tag);
               
            }
        }
    }
    public void EnemigoEntraEnCombate(GameObject n)
    {

        enemigosCombate.Add(n);
        if (enemigosCombate.Count == 1 && !charAnimator.GetBool("enPelea")) //Primer enemigo y el jugador no estaba en combate
        {
            StartCoroutine(EntrarEnPelea());
            
        }

    }

    IEnumerator EntrarEnPelea()
    {
        fuerzaLMB = true;
        while (charAnimator.GetCurrentAnimatorStateInfo(1).IsName("Desarmado"))
        {
            yield return new WaitForEndOfFrame();
        }
        fuerzaLMB = false;
    }
    public void EnemigoSaleDeCombate(GameObject n)
    {


        enemigosCombate.Remove(n);

       
    }

    public void TiempoCombo()
    {

        charAnimator.SetBool("comboAcertado", false);

        StartCoroutine(Combo());

    }
    IEnumerator Combo()
    {
        float t = Time.time;

        while (t + 0.2f > Time.time)
        {
            yield return new WaitForFixedUpdate();
            if (LMB)
            {

                charAnimator.SetBool("comboAcertado", true);
            }
        }

    }


    public void ParentarHacha()
    {

        hacha.transform.SetParent(manoDer.transform);


    }
    public void DeParentarHacha()
    {

        hacha.transform.SetParent(espalda.transform);
        hacha.transform.localPosition = hachaPos;
        hacha.transform.localRotation = hachaRot;
    }

    public void ParentarArco()
    {

        arco.transform.SetParent(manoIzq.transform);


    }
    public void DeParentarArco()
    {

        arco.transform.SetParent(espalda.transform);
        arco.transform.localPosition = arcoPos;

        arco.transform.localRotation = arcoRot;

    }
    IEnumerator EstoySaltando()
    {
        bool b = true;

        while (b)
        {
            AnimatorStateInfo aSInfo = charAnimator.GetCurrentAnimatorStateInfo(0);

            b = !aSInfo.IsName("Saltar");

            yield return new WaitForEndOfFrame();
        }

        saltando = true;
        float tTotal = 1;
        float tActual = 0;


        while (tActual < tTotal)
        {
            AnimatorStateInfo aState = charAnimator.GetCurrentAnimatorStateInfo(0);
            AnimatorClipInfo[] aClip = charAnimator.GetCurrentAnimatorClipInfo(0);

            tTotal = aClip[0].clip.length;
            tActual = aClip[0].clip.length * aState.normalizedTime;

            //Debug.Log("Esta animacion dura " + tTotal + " y vamos por: " + tActual);

            yield return new WaitForEndOfFrame();
        }

        saltando = false;


    }
    IEnumerator DerechoJoystickRetarded()
    {
        JD = true;


        yield return new WaitForSeconds(2);



        coroutineJD = null;

    }

    bool IzquierdoJoystick()
    {


        return (leftHorizontalInput != 0 || leftVerticalInput != 0) ? true : false;
    }


    bool DerechoJoystick()
    {



        return (rightVerticalInput != 0 || rightHorizontalInput != 0) ? true : false;
    }

    public bool EstoyEnPelea()
    {

        return charAnimator.GetBool("enPelea");

    }
  
}
