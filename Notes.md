# Unity

awake exécuté à la création de l'objet, start plus tard juste avant l'appel des update

pas de getcomponent dans update, pas bon pour la perf

```
public float Speed = 2f;
public GameObject PrefabShoot;

void awake()
{
  m_renderer = GetComponent<SpriteRenderer>();
}

void update()
{
    if (Input.GetKey(KeyCode.UpArrow)){
      transform.position += new Vector(0, 1, 0) * Time.deltaTime * Speed;
    }
    if (Input.GetKey(KeyCode.RightArrow)){
      transform.position += new Vector(1, 0, 0) * Time.deltaTime * Speed;
    }
    if (Input.GetKey(KeyCode.LeftArrow)){
      transform.position += new Vector(-1, 0, 0) * Time.deltaTime * Speed;
    }
    if (Input.GetKey(KeyCode.DownArrow)){
      transform.position += new Vector(0, -1, 0) * Time.deltaTime * Speed;
    }

    m_shootTimer -= Time.deltaTime;
    if(Input.GetKeyDown(KeyCode.Space))
    {
      if(m_shootTimer <= 0)
      {
        float angle = Random.Range(-0.2f, 0.2f) + Mathf.PI / 2.0f;

        GameObject.Instantiate(PrefabShoot, transform.position + new Vector3(0.2f, 0, 0), Quaternion.identity);
        shoot.GetComponent<ShootComponent>().Direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
        shoot.GetComponent<ShootComponent>().Speed = Random.Range(4, 6);

        //GameObject.Instantiate(PrefabShoot, transform.position + new Vector3(0.2f, 0, 0), Quaternion.identity);
        //shoot.GetComponent<ShootComponent>().Direction = new Vector3(-1, 1).normalized;

        //GameObject.Instantiate(PrefabShoot, transform.position + new Vector3(0.2f, 0, 0), Quaternion.identity);
        //shoot.GetComponent<ShootComponent>().Direction = new Vector3(1, 1).normalized;

        //GameObject.Instantiate(PrefabShoot, transform.position + new Vector3(0.2f, 0, 0), Quaternion.identity);
        //GameObject.Instantiate(PrefabShoot, transform.position - new Vector3(0.2f, 0, 0), Quaternion.identity);
        m_shootTimer = 0.1f; //pour tirer toutes les 100ms
      }
    }
}

void Move(Vector3 direction){
  transform.position += direction * Time.deltaTime * Speed;
}

SpriteRenderer m_renderer;

```

```
public float Speed = 10f;
public float deadTime = 1000f;

void update()
{
    transform.position += Direction * Time.deltaTime * Speed;
    GameObject.Destroy(gameObject, 2);

}

void OnTriggerEnter2D(Collider2D collider)
{
  Debug.Log("coucou");
  if (collider.gameObject.GetComponent<ShootComponent>())
    return;

  GameObject.Destroy(gameObject);
}
```

Ennemi, on lui ajoute un collider 2D triggered, un rigidbody2D kinematic
Shoot, circle collider2D triggered, Rigidbody2D kinematic
```
public float life = 100f;

void update()
{
    if (life <= 0){
      GameObject.Destroy(gameObject);
    }
}

void OnTriggerEnter2D(Collider2D collider)
{
  Debug.Log("coucou2");
  if (collider.gameObject.GetComponent<ShootComponent>())
    life -= 2;
}
```

livre design patern
