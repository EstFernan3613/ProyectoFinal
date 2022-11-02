using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogPersonajeP : MonoBehaviour
{

    public int fuerzaExtraSalto = 0;
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    public float x,y;
    public Animator anim;
    public Rigidbody rb;
    public float fuerzaSalto = 8f;
    public bool puedoSaltar;

    public float velocidadInicial;
    public float velocidadAgachado;

    public int velCorrer;

    public CapsuleCollider colParado;
    public CapsuleCollider colAgachado;
    public GameObject cabeza;
    public LogicaCabeza logicaCabeza;
    public bool estoyAgachado;

    public bool estoyAtacando;
    public bool AvanzoSolo;
    public float pulsoGolpe = 10f;


    // Start is called before the first frame update
    void Start()
    {
        puedoSaltar = false;
        anim = GetComponent<Animator>();
        velocidadInicial = velocidadMovimiento;
        velocidadAgachado = velocidadMovimiento * 0.5f;
    }


    void FixedUpdate()
    {
        if(!estoyAtacando)
        {

        transform.Rotate(0, x*Time.deltaTime*velocidadRotacion, 0);
        transform.Translate(0,0, y*Time.deltaTime*velocidadMovimiento); 


        }
        
        if(AvanzoSolo)
        {
            rb.velocity = transform.forward * pulsoGolpe;
        }
    }
    // Update is called once per frame
    void Update()
    {

        


        if(Input.GetKey(KeyCode.LeftShift)&& !estoyAgachado && puedoSaltar)
        {
            velocidadMovimiento = velCorrer;
            if(y > 0)
            {
                anim.SetBool("Correr",true);
            }
            else
            {
                anim.SetBool("Correr",false);
            }
        }
        else
        {
            anim.SetBool("Correr", false);
            if(estoyAgachado)
            {
                velocidadMovimiento = velocidadAgachado;
            }
            else if(puedoSaltar)
            {
                velocidadMovimiento = velocidadInicial;
            }
        }


        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if(Input.GetKeyDown(KeyCode.Return) && puedoSaltar && !estoyAtacando)
        {
            anim.SetTrigger("Golpeo");
            estoyAtacando = true;
        }


        if(puedoSaltar)
        {
            if(!estoyAtacando)
            {
                 if(Input.GetKeyDown(KeyCode.Space))
            {
                anim.SetBool("Salte", true);
                rb.AddForce(new Vector3(0, fuerzaSalto, 0), ForceMode.Impulse);
            }


            if(Input.GetKey(KeyCode.LeftControl))
            {
                anim.SetBool("Agachado", true);
                //velocidadMovimiento = velocidadAgachado;
                colAgachado.enabled = true;
                colParado.enabled = false;

                cabeza.SetActive(true);
                estoyAgachado = true;
            }
            else
            {
                if(logicaCabeza.contadorColision <= 0)
                {
                    anim.SetBool("Agachado", false);
                    //velocidadMovimiento = velocidadInicial;

                    cabeza.SetActive(false);
                    colAgachado.enabled = false;
                    colParado.enabled = true;
                    estoyAgachado = false; 
                }
                
                }
            }   
            
            
            anim.SetBool("TocaSuelo", true);
        } 
        else
        {
            Cayendo();
        }
    }

    public void Cayendo()
    {
        rb.AddForce(fuerzaExtraSalto * Physics.gravity);
        anim.SetBool("TocaSuelo", false);
        anim.SetBool("Salte", false);
    }


    public void  DejarGolpear()
    {
        estoyAtacando = false;
        AvanzoSolo = false;
    }

    public void AnanzoSolo()
    {
        AvanzoSolo = true;
    }

    public void DejarAvanzar()
    {
        AvanzoSolo = false;
    }
}
