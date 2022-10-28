using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgarreAscensor : MonoBehaviour
{

    AscensorMovimiento ascensor;
    // Start is called before the first frame update
    void Start()
    {
        ascensor = GetComponent<AscensorMovimiento>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ascensor.puedeMoverse = true;
    }
}
