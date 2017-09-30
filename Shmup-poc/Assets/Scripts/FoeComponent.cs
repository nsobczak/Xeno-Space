using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeComponent : MonoBehaviour
{
    public float Life = 100f;
    public float Speed = 20f;

    private Vector3 _direction = new Vector3(-2f, -1f, 1);

    void Update()
    {
        if (Life <= 0)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            Move();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<ShootComponent>())
            Life -= 1;
    }

    void Move()
    {
        transform.position += _direction * Time.deltaTime * Speed;

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x <= 0 || screenPos.x >= Screen.width || screenPos.y <= Screen.height/4 || screenPos.y >= Screen.height)
        {
            float angle = Random.Range(-0.5f, 0.5f);
            if (screenPos.x >= Screen.width)
                angle += Mathf.PI;
            if (screenPos.y <= Screen.height/4)
                angle += Mathf.PI / 2.0f;
            else if (screenPos.y >= Screen.height)
                angle -= Mathf.PI / 2.0f;
            _direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * Speed;
        }
    }
}