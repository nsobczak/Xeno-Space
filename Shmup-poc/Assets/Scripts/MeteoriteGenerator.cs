using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteGenerator : MonoBehaviour
{
    public GameObject[] PrefabMeteoriteList;

    public static int MeteoriteNumber = 0;
    public static int MaxMeteoriteNumber = 3;

    private float _spawnTimer = 1.5f;

    void Update()
    {
        _spawnTimer -= Time.deltaTime;
        if (_spawnTimer <= 0)
        {
            //Generate
            if (MeteoriteNumber < MaxMeteoriteNumber)
            {
                Vector3 position = new Vector3(transform.position.x + Random.Range(-3.5f, 3.5f),
                    transform.position.y, -1);
                GameObject.Instantiate(PrefabMeteoriteList[Random.Range(0, PrefabMeteoriteList.Length)], position,
                    Quaternion.identity);
                MeteoriteNumber += 1;
            }
            _spawnTimer = 2f;
        }
    }
}