using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoEnemig : MonoBehaviour
{

    public Animator ani;
    public Enemigo enemigo;

    public void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("Player"))
        {
            ani.SetBool("walk", false);
            ani.SetBool("run", false);
            ani.SetBool("attack", true);
            enemigo.atacandoEnemigo = true;
            GetComponent<CapsuleCollider>().enabled = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
