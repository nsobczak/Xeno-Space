using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public int MainMenuId = 0;
    public float Life = 10f;
    public Slider HealthSlider;
    public static int Score;
    public Text ScoreText;
    public float Speed = 2f;
    public GameObject[] PrefabShootList;
    public GameObject[] PrefabSwitchShootList;

    private GameObject _prefabShoot;
    private float _mShootTimer = 0.1f;

    private void GameOver()
    {
        Debug.Log("Game Over");
        SceneManager.LoadScene(MainMenuId);
    }

    void Start()
    {
        Score = 0;
        _prefabShoot = PrefabShootList[0];
    }

    private void Shoot()
    {
        if (_mShootTimer <= 0)
        {
            GameObject shoot;

            shoot = GameObject.Instantiate(_prefabShoot, transform.position + new Vector3(-0.2f, 0, 0),
                Quaternion.identity);
            shoot.GetComponent<PlayerShootComponent>().Direction = new Vector3(-1, 1).normalized;

            shoot = GameObject.Instantiate(_prefabShoot, transform.position + new Vector3(0.2f, 0, 0),
                Quaternion.identity);
            shoot.GetComponent<PlayerShootComponent>().Direction = new Vector3(1, 1).normalized;

            shoot = GameObject.Instantiate(_prefabShoot, transform.position + new Vector3(0.2f, 0, 0),
                Quaternion.identity);
            shoot.GetComponent<PlayerShootComponent>().Direction = new Vector3(0, 1);
            shoot = GameObject.Instantiate(_prefabShoot, transform.position + new Vector3(-0.2f, 0, 0),
                Quaternion.identity);
            shoot.GetComponent<PlayerShootComponent>().Direction = new Vector3(0, 1);

            _mShootTimer = 0.1f; //pour tirer toutes les 100ms
        }
    }

    void Update()
    {
        _mShootTimer -= Time.deltaTime;
        Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position); //stay in screen

#if UNITY_STANDALONE || UNITY_WEBPLAYER //move
        if (Input.GetKey(KeyCode.UpArrow) && screenPos.y < Screen.height)
        {
            transform.position += new Vector3(0, 3, 0) * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) && screenPos.x < Screen.width)
        {
            transform.position += new Vector3(3, 0, 0) * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.LeftArrow) && screenPos.x > 0)
        {
            transform.position += new Vector3(-3, 0, 0) * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.DownArrow) && screenPos.y > 0)
        {
            transform.position += new Vector3(0, -3, 0) * Time.deltaTime * Speed;
        }
        //shoot
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    
        #elif UNITY_ANDROID

        if (Input.touchCount > 0 || Input.GetMouseButton(0))
        {
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 touch;
            if (Input.touchCount > 0)
                touch = Input.touches[0].position;
            else
                touch = Input.mousePosition;

            //right
            if (touch.x > screenPosition.x && screenPos.x < Screen.width)
            {
                transform.position += new Vector3(3, 0, 0) * Time.deltaTime * Speed;
            }
            //left
            if (touch.x < screenPosition.x && screenPos.x > 0)
            {
                transform.position += new Vector3(-3, 0, 0) * Time.deltaTime * Speed;
            }
            //down
            if (touch.y < screenPosition.y && screenPos.y > 0)
            {
                transform.position += new Vector3(0, -3, 0) * Time.deltaTime * Speed;
            }
            //up
            if (touch.y > screenPosition.y && screenPos.y < Screen.height)
            {
                transform.position += new Vector3(0, 3, 0) * Time.deltaTime * Speed;
            }
        }
        Shoot();

#endif

        //update score
        ScoreText.text = Score.ToString();

        //game over
        if (Life <= 0)
        {
            GameOver();
        }
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<FoeShootComponent>())
        {
            Life -= 1;
            HealthSlider.value = Life;
        }
        if (collider.gameObject.GetComponent<FoeComponent>())
        {
            Life -= 10;
            HealthSlider.value = Life;
        }
        if (collider.gameObject.CompareTag("Meteorite"))
        {
            Life -= 4;
            HealthSlider.value = Life;
        }
        if (collider.gameObject.name == "ShootSwitchCapsule01" ||
            collider.gameObject.name == "ShootSwitchCapsule01(Clone)")
        {
            _prefabShoot = PrefabShootList[0];
        }
        if (collider.gameObject.name == "ShootSwitchCapsule03" ||
            collider.gameObject.name == "ShootSwitchCapsule03(Clone)")
        {
            _prefabShoot = PrefabShootList[PrefabShootList.Length - 1];
        }
    }
}