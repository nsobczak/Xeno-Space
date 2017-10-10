using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteScript : MonoBehaviour
{
    public float Life = 10f;
    public float Speed = 3f;

    private Vector3 _direction;
    private float _rotation;

    void Start()
    {
        //appear with random direction
        _direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1.5f, -0.5f), 0);
        _rotation = Random.Range(-10f, 10f);
    }

    void Update()
    {
        if (Life <= 0)
        {
            GameObject.Destroy(gameObject);
            MeteoriteGenerator.MeteoriteNumber -= 1;
        }
        else
        {
            transform.position += _direction * Time.deltaTime * Speed;
            transform.eulerAngles += new Vector3(0, 0, _rotation);

            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

            if (screenPos.x <= 0 || screenPos.x >= Screen.width || screenPos.y <= 0)
            {
                GameObject.Destroy(gameObject);
                MeteoriteGenerator.MeteoriteNumber -= 1;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerShootComponent>())
            Life -= 1;
    }
}