using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public static String Timer;
    
    private float _startTime;
    private Text _textTime;

    void Awake()
    {
        _startTime = Time.time;
    }

    void Start()
    {
        _textTime = GetComponent<Text>();
    }

    void Update()
    {
        if (!ShowPanels.IsGameFinished)
        {
            float currentTime = Time.time - _startTime;

            int minutes = (int) (currentTime / 60);
            int seconds = (int) (currentTime % 60);
            int fraction = (int) ((currentTime * 100) % 100);

            Timer = String.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
            _textTime.text = Timer;
        }
    }
}