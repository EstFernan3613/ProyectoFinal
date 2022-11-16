using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrarBotonMenu : MonoBehaviour
{
    public GameObject canvas;
    public bool IsOn = false;

    // Start is called before the first frame update
    void Start()
    {
        canvas.SetActive(false);
    }

    

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (IsOn == false)
            {

                MostrarOpciones();
                IsOn = true;
            }

            else
            {
                
                OcultarOpciones();
                IsOn = false;
            }


        }

    }
    public void MostrarOpciones()
    {
        canvas.SetActive(true);
        
    }
    public void OcultarOpciones()
    {
        canvas.SetActive(false);
        
    }
}
