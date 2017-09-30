using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 2f;
    public GameObject PrefabShoot;

    private float m_shootTimer = 0.1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += new Vector3(0, 3, 0) * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(3, 0, 0) * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-3, 0, 0) * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -3, 0) * Time.deltaTime * Speed;
        }

        m_shootTimer -= Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            if (m_shootTimer <= 0)
            {
                GameObject shoot;
//                float angle = Random.Range(-0.2f, 0.2f) + Mathf.PI / 2.0f;
//                GameObject.Instantiate(PrefabShoot, transform.position + new Vector3(0.2f, 0, 0), Quaternion.identity);
//                shoot.GetComponent<ShootComponent>().Direction =
//                    new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
//                shoot.GetComponent<ShootComponent>().Speed = Random.Range(4, 6);

                shoot = GameObject.Instantiate(PrefabShoot, transform.position + new Vector3(0.2f, 0, 0),
                    Quaternion.identity);
                shoot.GetComponent<ShootComponent>().Direction = new Vector3(-1, 1).normalized;

                shoot = GameObject.Instantiate(PrefabShoot, transform.position + new Vector3(0.2f, 0, 0),
                    Quaternion.identity);
                shoot.GetComponent<ShootComponent>().Direction = new Vector3(1, 1).normalized;

                shoot = GameObject.Instantiate(PrefabShoot, transform.position + new Vector3(0.2f, 0, 0),
                    Quaternion.identity);
                shoot.GetComponent<ShootComponent>().Direction = new Vector3(0, 1);
                shoot = GameObject.Instantiate(PrefabShoot, transform.position - new Vector3(0.2f, 0, 0),
                    Quaternion.identity);
                shoot.GetComponent<ShootComponent>().Direction = new Vector3(0, 1);

                m_shootTimer = 0.1f; //pour tirer toutes les 100ms
            }
        }
    }

    void Move(Vector3 direction)
    {
        transform.position += direction * Time.deltaTime * Speed;
    }
}