using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimacionTexto2 : MonoBehaviour
{
    string frase2 = "NO HAY VUEALTA ATRAS!" + " " +
                    "Necesitas un favor?" + " " +
                    "yo tambien necesito uno..." + " " +
                    "busca la casa en el bosque, puede que vuelvas a ver a tu novia...";
 
 
 
    public Text texto2;
    public GameObject SonidoEscritura2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reloj2());

    }
    IEnumerator Reloj2()
    {
        Instantiate(SonidoEscritura2);

        foreach (char caracter in frase2)
        {
            texto2.text = texto2.text + caracter;
            yield return new WaitForSeconds(0.08f);
        }
    }
}