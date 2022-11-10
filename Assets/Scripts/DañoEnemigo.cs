using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoEnemigo : MonoBehaviour
{


    public float vidaJugador = 100f;
    public float dañoDelEnemigo = 2.0f;
    public LogicaBarraVida logicaBarraVidaJugadorX;
    [SerializeField] private Transform Player;
    [SerializeField] private Transform respawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("dañoEnemigo"))
        {
            logicaBarraVidaJugadorX.vidaActual -= dañoDelEnemigo;

        }
    }
}
