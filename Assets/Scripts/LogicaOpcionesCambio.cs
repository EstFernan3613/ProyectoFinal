using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaOpcionesCambio : MonoBehaviour
{
    public ControladorDeOpciones panelOpciones;
    public bool IsPause = false;

    // Start is called before the first frame update
    void Start()
    {
        panelOpciones = GameObject.FindGameObjectWithTag("opciones").GetComponent<ControladorDeOpciones>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (IsPause == false)
            {
                MostrarOpciones();
                IsPause = true;
            }

            else
            {
                OcultarOpciones();
                IsPause = false;
            }
            
                
        }
    }

    public void MostrarOpciones() 
    {
        panelOpciones.pantallaOpciones.SetActive(true);
        Time.timeScale = 0f;
    }
    public void OcultarOpciones()
    {
        panelOpciones.pantallaOpciones.SetActive(false);
        Time.timeScale = 1f;
    }
}
