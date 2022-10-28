using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AscensorMovimiento : MonoBehaviour
{   

    public bool puedeMoverse;
    [SerializeField] float velocidadAscensor;
    [SerializeField] int puntoInicio;
    [SerializeField] Transform [] puntos;

    int i;
    bool reversa;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = puntos[puntoInicio].position;
        i = puntoInicio;
    }

    // Update is called once per frame
    void Update()
    {


        if(Vector3.Distance(transform.position, puntos[i].position) < 0.01f)    
        {
            puedeMoverse = false;
            if(i == puntos.Length - 1)
            {
                reversa = true;
                i--;
                return;
            }else if(i == 0)
            {
                reversa = true;
                i++;
                return;
            }

            if(reversa)
            {
                i--;
            }
            else
            {
                i++;
            }
        }
        if(puedeMoverse)
        {
            transform.position = Vector3.MoveTowards(transform.position, puntos[i].position, velocidadAscensor * Time.deltaTime);
        }
    }
}
