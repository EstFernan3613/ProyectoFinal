using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Daño : MonoBehaviour
{
    public float vida = 50f;
    public LogicaBarraVida logicaBarraVidaJugador;
    public float daño = 2.0f;
    public float RestartVida;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnPoint;
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            logicaBarraVidaJugador.vidaActual -= daño;
            Player.transform.position = respawnPoint.transform.position;

            if(Player.transform.position == respawnPoint.transform.position)
            {
                logicaBarraVidaJugador.vidaActual = RestartVida;
            
            }
            else if(other.CompareTag("dañoEnemigo"))
            {
                logicaBarraVidaJugador.vidaActual -= daño;
            }

            
        }

       
    
    }
   
}
