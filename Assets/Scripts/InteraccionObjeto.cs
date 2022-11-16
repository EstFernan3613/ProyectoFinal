using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionObjeto : MonoBehaviour
{
    Inventario Calavera;

    // Start is called before the first frame update
    void Start()
    {
        Calavera = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Calavera.Calaveras = Calavera.Calaveras + 1;
        }

        Destroy(gameObject);
    }
}
