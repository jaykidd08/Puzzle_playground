using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer;
    private int seconds;
    private int minutes;
    private string secondFormat;
    void Start()
    {
        timer = 0.0f;
        GameObject.Find("TimerUI").GetComponent<TextMeshProUGUI>().text = "0:00";
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        seconds = (int)(timer % 60);
        minutes = (int)(timer / 60);
        secondFormat = seconds.ToString("00");
        GameObject.Find("TimerUI").GetComponent<TextMeshProUGUI>().text = "" + minutes + ":" + secondFormat;
        //Debug.Log(minutes + ":" + seconds);
    }
}
