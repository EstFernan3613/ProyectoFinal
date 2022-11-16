using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardar : MonoBehaviour
{
    public static Guardar instance;
    private void Awake()
    {
        if (instance== null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
     
    }

    private void start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void timedata(float value)
    {
        PlayerPrefs.SetFloat("TimeData", value);
    }
  
}
