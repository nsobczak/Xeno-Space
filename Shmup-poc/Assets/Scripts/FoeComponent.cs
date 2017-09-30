using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeComponent : MonoBehaviour
{
    public float Life = 100f;

    void Update()
    {
        if (Life <= 0)
        {
            GameObject.Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<ShootComponent>())
            Life -= 1;
    }
}