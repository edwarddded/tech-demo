using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBoss : MonoBehaviour
{
    public float speed = 200f;

    public GameObject item, BlueFireball;

    SpriteRenderer sr;
    public float Icebosshealth = 50f;
    public float time = 8f;
    private Rigidbody2D rb;
    public Animator Ani;

    public bool enemyright = true;
    public Transform Firepoint;
    public float spawnTime = 2;
    public float spawnDelay = 7;

    private BossHealthBar healthBar;
    public GameObject ToicePortal;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        healthBar = GameObject.Find("Healthbar").GetComponent<BossHealthBar>();
        healthBar.setMaxHealth(Icebosshealth);
        InvokeRepeating("Fireball", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Enemy Movement
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
        if (enemyright)
        {
            transform.localScale = new Vector2(6, 6);
            rb.velocity = new Vector2(speed * Time.fixedDeltaTime * 1, rb.velocity.y);
        }
        else
        {
            transform.localScale = new Vector2(-6, 6);
            rb.velocity = new Vector2(speed * -1 * Time.fixedDeltaTime, rb.velocity.y);
        }

        if (transform.localScale.x < 0.1)
        {
            Firepoint.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            Firepoint.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("turn"))
        {
            if (enemyright)
            {
                enemyright = false;
            }
            else
            {
                enemyright = true;
            }
        }

    }

    private void Update()
    {
        SetAttackAnimation();
        if (Icebosshealth < 20)
        {
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            sr.material.color = Color.red;
        }
    }
    void SetAttackAnimation()
    {

        time = time - Time.deltaTime;
        Debug.Log(time);
        if (time < 0)
        {
            time = 8f;
        }
        if (time < 2.5)
        {
            Ani.SetBool("IsAttack", true);

            if (transform.localScale.x < 0.1)
            {
                Firepoint.transform.rotation = Quaternion.Euler(Firepoint.rotation.x, 180, 0);

            }
            else
            {
                Firepoint.transform.rotation = Quaternion.Euler(Firepoint.rotation.x, 0, 0);

            }

        }
        else
        {
            Ani.SetBool("IsAttack", false);
        }
    }
    public void Fireball()
    {
        Instantiate(BlueFireball, Firepoint.position, Firepoint.rotation * Quaternion.Euler(0, 0, 45));

        Instantiate(BlueFireball, Firepoint.position, Firepoint.rotation * Quaternion.Euler(0, 0, 90));

        Instantiate(BlueFireball, Firepoint.position, Firepoint.rotation * Quaternion.Euler(0, 0, 135));

        Instantiate(BlueFireball, Firepoint.position, Firepoint.rotation * Quaternion.Euler(0, 0, 180));

        Instantiate(BlueFireball, Firepoint.position, Firepoint.rotation * Quaternion.Euler(0, 0, 225));

        Instantiate(BlueFireball, Firepoint.position, Firepoint.rotation * Quaternion.Euler(0, 0, 270));

        Instantiate(BlueFireball, Firepoint.position, Firepoint.rotation * Quaternion.Euler(0, 0, 315));

        Instantiate(BlueFireball, Firepoint.position, Firepoint.rotation * Quaternion.Euler(0, 0, 360));


    }
    public void TakeDamage(float damage)
    {
        Icebosshealth -= damage;
        healthBar.SetHealth(Icebosshealth);
        Debug.Log(Icebosshealth);
        if (Icebosshealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(item, gameObject.transform.position, gameObject.transform.rotation);
        Vector3 ToFinal = new Vector3(38f, 2.2f, 0);
        Instantiate(ToicePortal, ToFinal, transform.rotation);
        Destroy(gameObject);
    }
}
