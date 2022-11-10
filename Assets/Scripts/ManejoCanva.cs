using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManejoCanva : MonoBehaviour
{
    public Text titulo;
    public GameObject panelM1;
    public GameObject panelM2;
    public GameObject panelM3;
    public GameObject panelM4;

    // Start is called before the first frame update
    void Start()
    {
        titulo.text = "Lucid Dreams";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CambiarAP2()
    {
        panelM1.SetActive(false);
        panelM2.SetActive(true);
    }

    public void CambiarAP1()
    {
        panelM1.SetActive(true);
        panelM2.SetActive(false);
    }
    public void CambiarAP3()
    {
        panelM1.SetActive(false);
        panelM3.SetActive(true);
    }
    public void CambiarAP4()
    {
        panelM1.SetActive(false);
        panelM4.SetActive(true);
    }
    public void CambiarAP3off()
    {
        panelM1.SetActive(true);
        panelM3.SetActive(false);
    }
    public void CambiarAP4off()
    {
        panelM1.SetActive(true);
        panelM4.SetActive(false);
    }
}
