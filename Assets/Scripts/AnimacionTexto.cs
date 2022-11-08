using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimacionTexto : MonoBehaviour
{
    string frase = "Se porque estas aqui... " + " " +
                    "he sentido tu tristeza y desesperacion desde kilometros," + " " +
                    "se lo que buscas...";
    public Text texto;
    public GameObject SonidoEscritura;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reloj());

    }
    IEnumerator Reloj()
    {
        Instantiate(SonidoEscritura);
        foreach (char caracter in frase)
        {
            
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.1f);
        }
    }
}