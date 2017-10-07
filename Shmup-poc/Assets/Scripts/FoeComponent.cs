using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeComponent : MonoBehaviour
{
    public float Life = 100f;
    public float Speed = 10f;
    public GameObject PrefabShoot;
    public FoeGenerator FoeGenerator;
    
    private float _mShootTimer = 0.5f;
    private Vector3 _direction = new Vector3(-2f, -1f, 0);

    void Update()
    {
        if (Life <= 0)
        {
            PlayerController.Score += 100;
            GameObject.Destroy(gameObject);
            FoeGenerator.FoeNumber -= 1;
        }
        else
        {
            Move();

            //shoot
            _mShootTimer -= Time.deltaTime;
            if (_mShootTimer <= 0)
            {
                GameObject shoot;
                Vector3 shootOrigin = transform.position + new Vector3(0, 0, 1);
                
                shoot = GameObject.Instantiate(PrefabShoot, shootOrigin + new Vector3(-0.4f, 0, 0),
                    Quaternion.identity);
                shoot.GetComponent<FoeShootComponent>().Direction = new Vector3(-1, -1).normalized;
                
                shoot = GameObject.Instantiate(PrefabShoot, shootOrigin + new Vector3(0.4f, 0, 0),
                    Quaternion.identity);
                shoot.GetComponent<FoeShootComponent>().Direction = new Vector3(1, -1).normalized;
                
                shoot = GameObject.Instantiate(PrefabShoot, shootOrigin + new Vector3(0, -0.6f, 0),
                    Quaternion.identity);
                shoot.GetComponent<FoeShootComponent>().Direction = new Vector3(0, -1);
               
                _mShootTimer = 0.5f; //pour tirer toutes les 100ms
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerShootComponent>())
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