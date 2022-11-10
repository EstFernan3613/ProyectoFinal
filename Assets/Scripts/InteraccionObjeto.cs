using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteraccionObjeto : MonoBehaviour
{
    Inventario Calaveras;

    // Start is called before the first frame update
    void Start()
    {
        Calaveras = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Calaveras.Cantidad = Calaveras.Cantidad + 1;
        }

        Destroy(gameObject);
    }
}
