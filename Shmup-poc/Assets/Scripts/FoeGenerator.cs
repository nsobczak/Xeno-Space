using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeGenerator : MonoBehaviour
{
    public GameObject PrefabFoe;

    public static int FoeNumber = 0;
    public static int MaxFoeNumber = 1;
        
    void Update()
    {
        if (FoeNumber < MaxFoeNumber)
        {
            GameObject.Instantiate(PrefabFoe, transform.position, Quaternion.Euler(0, 0, 180));
            FoeNumber += 1;
        }
    }
}