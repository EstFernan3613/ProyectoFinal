using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JefeFinal : MonoBehaviour
{

    public int rutinaJefe;
    public float cronometroJefe;
    public float time_rutina;
    public Animator animJefe;
    public Quaternion angulo;
    public float gradoJefe;
    public GameObject targetP;
    public bool atacando;
    public RangoJefeFinal rangoJefe;
    public float speed;
    public GameObject[] hit;
    public int hit_select;

    public Enemigo enemy;



    public bool lanza_llamas;
    public List<GameObject> pool = new List<GameObject>();
    public GameObject fire;
    public GameObject cabezaJefe;
    public float cronometroJefe2;

    public float jump_distance;
    public bool direction_skill;

    public GameObject bola_fuego;
    public GameObject point;
    public List<GameObject> pool2 = new List <GameObject>();

    public int fase = 1;
    public float HP_Min;
    public float HP_Max;
    public Image BarraEnemy;
    public bool muerto;


    // Start is called before the first frame update
    void Start()
    {
        animJefe = GetComponent<Animator>();
        targetP = GameObject.Find("PersonajeP");
    }

    public void ComportamientoJefe()
    {
        if(Vector3.Distance(transform.position, targetP.transform.position) < 15)
        {
            var lookPos = targetP.transform.position - transform.position;
            lookPos.y = 0;
            var rotation = Quaternion.LookRotation(lookPos);
            point.transform.LookAt(targetP.transform.position);
        
        if(Vector3.Distance(transform.position, targetP.transform.position) > 1 && !atacando)
        {
            switch(rutinaJefe)
            {
                case 0:
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        animJefe.SetBool("walk", true);
                        animJefe.SetBool("run", false);
                        if(transform.rotation == rotation)
                        {
                            transform.Translate(Vector3.forward * speed * Time.deltaTime);
                        }
                        animJefe.SetBool("attack", false);
                        cronometroJefe += 1 * Time.deltaTime;
                        if(cronometroJefe > time_rutina)
                        {
                            rutinaJefe = Random.Range(0,5);
                        }
                        break;
                case 1:
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        animJefe.SetBool("walk", false);
                        animJefe.SetBool("run", true);
                        if(transform.rotation == rotation)
                        {
                            transform.Translate(Vector3.forward * speed * 2 * Time.deltaTime);
                        }
                        animJefe.SetBool("attack", false);
                        break;
                case 2:
                        animJefe.SetBool("walk", false);
                        animJefe.SetBool("run", false);
                        animJefe.SetBool("attack", true);
                        animJefe.SetFloat("skills", 0.8f);
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                        rangoJefe.GetComponent<CapsuleCollider>().enabled = false;
                        break;

                case 3:
                        if(fase == 2)
                        {
                            jump_distance += 1 * Time.deltaTime;
                            animJefe.SetBool("walk", true);
                            animJefe.SetBool("run", false);
                            animJefe.SetBool("attack", true);
                            animJefe.SetFloat("skills", 0.6f);
                            hit_select = 3;
                            rangoJefe.GetComponent <CapsuleCollider>().enabled = false;
                            if(direction_skill)
                            {
                                if(jump_distance < 1f)
                                {
                                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                                }
                                transform.Translate(Vector3.forward * 8 * Time.deltaTime);
                            }
                        }
                        else
                        {
                            rutinaJefe = 0;
                            cronometroJefe = 0;
                        }
                        break;

                case 4:
                        if(fase == 2)
                        {
                            animJefe.SetBool("walk", false);
                            animJefe.SetBool("run", false);
                            animJefe.SetBool("attack", true);
                            animJefe.SetFloat("skills", 1);
                            rangoJefe.GetComponent <CapsuleCollider>().enabled = false;
                            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 0.5f);
                        }
                        else
                        {
                            rutinaJefe = 0;
                            cronometroJefe = 0;
                        }
                        break;
                }
            }
        }
    }

    public void Final_aniJefe()
    {
        rutinaJefe = 0;
         animJefe.SetBool("attack", false);
         atacando = false;
         rangoJefe.GetComponent<CapsuleCollider>().enabled = true;
         lanza_llamas = false;
         jump_distance = 0;
         direction_skill = false;
    }

    public void Direction_Attack_Start()
    {
        direction_skill = true;
    }
    public void Direction_Attack_Final()
    {
        direction_skill = false;
    }
    public void ColliderWeaponTrue()
    {
        hit[hit_select].GetComponent<SphereCollider>().enabled = true;
    }
    public void ColliderWeaponFalse()
    {
        hit[hit_select].GetComponent<SphereCollider>().enabled = false;
    }

    public GameObject GetBala()
    {
        for(int i=0; i < pool.Count; i++)
        {
            if(!pool[i].activeInHierarchy)
            {
                pool[i].SetActive(true);
                return pool[i];
            }
        }

        GameObject obj = Instantiate(fire, cabezaJefe.transform.position, cabezaJefe.transform.rotation) as GameObject;
        pool.Add(obj);
        return obj;
    }

    public void LanzaLlamas_Skill()
    {
        cronometroJefe2 += 1 * Time.deltaTime;
        if(cronometroJefe2 > 0.1f)
        {
            GameObject obj = GetBala();
            obj.transform.position = cabezaJefe.transform.position;
            obj.transform.rotation = cabezaJefe.transform.rotation;
            cronometroJefe2 = 0;
        }
    }


    public void Start_Fire()
    {
        lanza_llamas = true;
    }

    public void Stop_Fire()
    {
        lanza_llamas = false;
    }

    public GameObject Get_Fire_Ball()
    {
        for(int i=0; i < pool2.Count; i++)
        {
            if(!pool2[i].activeInHierarchy)
            {
                pool2[i].SetActive(true);
                return pool2[i];
            }
        }

        GameObject obj = Instantiate(bola_fuego, point.transform.position, point.transform.rotation) as GameObject;
        pool2.Add(obj);
        return obj;
    }


    public void Fire_Ball_Skill()
    {
        GameObject obj = Get_Fire_Ball();
        obj.transform.position = point.transform.position;
        obj.transform.rotation = point.transform.rotation;

    }


    public void Vivo()
    {
        if(HP_Min < 500)
        {
            fase = 2;
            time_rutina = 1;
        }

        ComportamientoJefe();

        if(lanza_llamas)
        {
            LanzaLlamas_Skill();
        }
    }

    



    // Update is called once per frame
    void Update()
    {
        BarraEnemy.fillAmount = HP_Min / HP_Max;
        if(HP_Min > 0)
        {
            Vivo();
        }
        else
        {
            if(!muerto)
            {
                animJefe.SetTrigger("dead");
                muerto = true;
            
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "armaImpacto")
        {
            HP_Min -= 50;
        }
    }



}
