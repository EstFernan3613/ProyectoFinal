using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timertext;
    public bool backwards;
    public float time;
    private int minutes;
    private int seconds;
    private int cents;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (backwards==true)
        {
            time -= Time.deltaTime;
            if (time < 0) time = 0;

        }
        else
        {
            time += Time.deltaTime;
        }

        minutes = (int) (time / 60f);
        seconds = (int)(time - minutes * 60f);
        cents = (int)((time - (int)time) * 100f);

        timertext.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, cents);

        time.value = PlayerPrefs.GetFloat("TimeData", 0);
    }
}
