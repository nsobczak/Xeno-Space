using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeShootComponent : MonoBehaviour
{
    public float Speed = 10f;
    public Vector3 Direction;
    public float LifeTime = 5f;

    void Update()
    {
        transform.position += Direction * Time.deltaTime * Speed;
        GameObject.Destroy(gameObject, LifeTime);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<FoeShootComponent>() || collider.gameObject.GetComponent<FoeComponent>() ||
            collider.gameObject.GetComponent<PlayerShootComponent>() ||
            collider.gameObject.GetComponent<ShootSwitchCapsule>())
            return;

        GameObject.Destroy(gameObject);
    }
}