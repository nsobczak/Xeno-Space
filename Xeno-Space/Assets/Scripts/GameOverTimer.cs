using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTimer : MonoBehaviour
{
    private Text _textTime; 
    
    // Use this for initialization
    void Start()
    {
        _textTime = GetComponent<Text>();
        _textTime.text = TimerScript.Timer;
    }
}