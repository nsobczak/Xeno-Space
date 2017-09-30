using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootComponent : MonoBehaviour
{
    public float Speed = 10f;
    public Vector3 Direction;

    void Update()
    {
        transform.position += Direction * Time.deltaTime * Speed;
        GameObject.Destroy(gameObject, 0.5f);
    }

//    void OnTriggerEnter2D(Collider2D collider)
//    {
//        Debug.Log("coucou");
//        if (collider.gameObject.GetComponent<ShootComponent>())
//            return;
//
//        GameObject.Destroy(gameObject);
//    }
}