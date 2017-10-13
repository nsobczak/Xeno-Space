using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSwitchCapsule : MonoBehaviour
{
    public float Speed = 3f;

    private Vector3 _direction;
    private float _rotation;
    private float _offsetDestruction = 10f;

    void Start()
    {
        //appear with random direction
        _direction = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-1f, -0.5f), 0);
        _rotation = Random.Range(-4f, 4f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _direction * Time.deltaTime * Speed;
        transform.eulerAngles += new Vector3(0, 0, _rotation);

        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

        if (screenPos.x <= -_offsetDestruction || screenPos.x >= Screen.width + _offsetDestruction ||
            screenPos.y <= -_offsetDestruction)
        {
            GameObject.Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerController>())
        {
            GameObject.Destroy(gameObject);
        }
    }
}