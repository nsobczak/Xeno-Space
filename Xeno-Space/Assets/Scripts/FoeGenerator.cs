using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeGenerator : MonoBehaviour
{
    public GameObject PrefabFoe;
    public float Speed = 1f;

    public static int FoeNumber = 0;
    public static int MaxFoeNumber = 1;

    private Vector3 _direction = new Vector3(-1f, 0, 0);
    private int addFoePitch = 5;

    void Update()
    {
        //Generate
        if (FoeNumber < MaxFoeNumber)
        {
            Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
            GameObject.Instantiate(PrefabFoe, position, Quaternion.Euler(0, 0, 180));
            FoeNumber += 1;
        }

        //Move
        transform.position += _direction * Time.deltaTime * Speed;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPos.x <= 0 + Screen.width / 4 || screenPos.x >= Screen.width - Screen.width / 4)
            _direction *= -1;

        //Add MaxFoeNumber with points
        int foeKilled = PlayerController.Score / 100;
        MaxFoeNumber = foeKilled / addFoePitch + 1;
    }
}