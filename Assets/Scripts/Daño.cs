using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Daño : MonoBehaviour
{
    public LogicaBarraVida logicaBarraVidaJugador;
    public float daño = 2.0f;
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            logicaBarraVidaJugador.vidaActual -= daño;
        }
    }
   
}
