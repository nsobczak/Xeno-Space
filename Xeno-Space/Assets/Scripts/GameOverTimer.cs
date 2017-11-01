using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTimer : MonoBehaviour
{
    private Text _textScore;

    // Use this for initialization
    void Start()
    {
        _textScore = GetComponent<Text>();
        _textScore.text = TimerScript.Timer;
    }
}