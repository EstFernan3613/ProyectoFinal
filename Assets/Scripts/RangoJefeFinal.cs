using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangoJefeFinal : MonoBehaviour
{

    public Animator ani;
    public JefeFinal jefeFinal;
    public int melee;

    void OnTriggerEnter(Collider coll)
    {
        if(coll.CompareTag("Player"))
        {
            melee = Random.Range(0,4);
            switch(melee)
            {
                case 0:
                        ani.SetFloat("skills", 0);
                        jefeFinal.hit_select = 0;
                        break;

                case 1:
                        ani.SetFloat("skills", 0.2f);
                        jefeFinal.hit_select = 1;
                        break;
                case 2:
                        ani.SetFloat("skills", 0.4f);
                        jefeFinal.hit_select = 2;
                        break;
                case 3:
                        if(jefeFinal.fase == 2)
                        {
                            ani.SetFloat("skills", 1);
                        }
                        else
                        {
                            melee = 0;    
                        }
                        break;
            }

            ani.SetBool("walk", false);
            ani.SetBool("run", false);
            ani.SetBool("attack", true);
            jefeFinal.atacando = true;
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
