using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBoss : MonoBehaviour
{
    public float speed = 200f;

    public GameObject item, BlueFireball;

    SpriteRenderer sr;
    public float firebosshealth = 50f;
    private float time = 8f;
    private Rigidbody2D rb;
    public Animator Ani;

    public bool enemyright = true;
    public Transform Firepoint;
    int i = 1;

    private BossHealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        healthBar = GameObject.Find("Healthbar").GetComponent<BossHealthBar>();
        healthBar.setMaxHealth(firebosshealth);
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
            if (Time.time > i)
            {
                i += 2;
                if (transform.localScale.x < 0.1)
                {
                    Firepoint.transform.rotation = Quaternion.Euler(Firepoint.rotation.x, 180, 0);
                    StartCoroutine(Fireball());
                }
                else
                {
                    Firepoint.transform.rotation = Quaternion.Euler(Firepoint.rotation.x, 0, 0);
                    StartCoroutine(Fireball());
                }
            }
        }
        else
        {
            Ani.SetBool("IsAttack", false);
        }
    }
    IEnumerator Fireball()
    {    
        Instantiate(BlueFireball, Firepoint.position, Firepoint.rotation * Quaternion.Euler(0, 0, 45));
        yield return new WaitForSeconds(0.15f);
        Instantiate(BlueFireball, Firepoint.position, Firepoint.rotation * Quaternion.Euler(0, 0, 90));
        yield return new WaitForSeconds(0.15f);
        Instantiate(BlueFireball, Firepoint.position, Firepoint.rotation * Quaternion.Euler(0, 0, 135));
        yield return new WaitForSeconds(0.15f);
        Instantiate(BlueFireball, Firepoint.position, Firepoint.rotation * Quaternion.Euler(0, 0, 180));
        yield return new WaitForSeconds(0.15f);
        Instantiate(BlueFireball, Firepoint.position, Firepoint.rotation * Quaternion.Euler(0, 0, 225));


    }
    public void TakeDamage(float damage)
    {
        firebosshealth -= damage;
        healthBar.SetHealth(firebosshealth);
        Debug.Log(firebosshealth);
        if (firebosshealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(item, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);
    }
}
