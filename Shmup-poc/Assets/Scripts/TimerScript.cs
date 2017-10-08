using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private float startTime;
    private Text textTime;

    void Awake()
    {
        startTime = Time.time;
    }

    void Start()
    {
        textTime = GetComponent<Text>();
    }

    void Update()
    {
        float currentTime = Time.time - startTime;
        
        int minutes = (int) (currentTime / 60);
        int seconds = (int) (currentTime % 60);
        int fraction = (int) ((currentTime * 100) % 100);
        
        textTime.text = String.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction); 
    }
}