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
        DontDestroyOnload(gameObject);
    }

    public void timedata(float value)
    {
        PlayerPrefs.Setfloat("TimeData", value);
    }
  
}
