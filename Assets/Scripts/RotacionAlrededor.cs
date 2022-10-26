using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionAlrededor : MonoBehaviour
{

    public GameObject ObjetoEstatico;
    public float velocidadRotar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(ObjetoEstatico.transform.position, Vector3.up, velocidadRotar * Time.deltaTime);
    }
}
