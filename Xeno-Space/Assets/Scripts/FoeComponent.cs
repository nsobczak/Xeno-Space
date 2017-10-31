using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoeComponent : MonoBehaviour
{
    public float Life = 80f;
    public float Speed = 10f;
    public GameObject PrefabShoot;
    public GameObject PlayerControllerGameObject;

    private int pointGiven = 100;
    private float _mShootTimer = 0.5f;
    private Vector3 _direction;
    private GameObject[] _prefabSwitchShootList;


    void Move()
    {
        transform.position += _direction * Time.deltaTime * Speed;

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x <= 0 || screenPos.x >= Screen.width || screenPos.y <= Screen.height / 3 ||
            screenPos.y >= Screen.height)
        {
            float angle = Random.Range(-1f, 1f);
            if (screenPos.x >= Screen.width)
                angle += Mathf.PI;
            if (screenPos.y <= Screen.height / 3)
                angle += Mathf.PI / 2.0f;
            else if (screenPos.y >= Screen.height)
                angle -= Mathf.PI / 2.0f;
            _direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * Speed;
        }
    }

    void Start()
    {
        //appear with random direction
        _direction = new Vector3(Random.Range(-2f, 2f), Random.Range(-1.5f, -0.5f), 0);
        _prefabSwitchShootList = PlayerControllerGameObject.GetComponent<PlayerController>().PrefabSwitchShootList;
    }

    void Update()
    {
        if (Life <= 0)
        {
            PlayerController.Score += pointGiven;
            GameObject.Destroy(gameObject);
            FoeGenerator.FoeNumber -= 1;
            int shootSwitchProbability = Random.Range(0, _prefabSwitchShootList.Length * 2);
            if (shootSwitchProbability < _prefabSwitchShootList.Length)
            {
                Vector3 position = new Vector3(transform.position.x, transform.position.y, 1);
                GameObject.Instantiate(_prefabSwitchShootList[shootSwitchProbability], position, Quaternion.identity);
            }
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
        {
            PlayerShootComponent shootComponent = collider.gameObject.GetComponent<PlayerShootComponent>();
            if (shootComponent.name == "Ball_01" ||
                shootComponent.name == "Ball_01(Clone)")
                Life -= 2;
            if (shootComponent.name == "Ball_03" ||
                shootComponent.name == "Ball_03(Clone)")
                Life -= 4;
        }
    }
}