using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 200f;

    public GameObject item;

    SpriteRenderer sr;
    public float health = 3f;

    private Rigidbody2D rb;
    public Animator EnemyAni;

    private GameObject raycastPoint;
    public GameObject Player;
    public Transform Sightendpos;
    public bool spotted = false;

    public bool enemyright= true;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        raycastPoint = transform.Find("RC").gameObject;
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        //Enemy Movement
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
        if (enemyright)
        {
            transform.localScale = new Vector2(6,6);
            rb.velocity = new Vector2(speed * Time.fixedDeltaTime * 1, rb.velocity.y);
        }
        else
        {
            transform.localScale = new Vector2(-6,6);
            rb.velocity = new Vector2(speed * -1 * Time.fixedDeltaTime, rb.velocity.y);
        }

        if (transform.localScale.x < 0.1)
        {
            raycastPoint.transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            raycastPoint.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    private void Update()
    {
        Raycasting();
        Behaviours();
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
    void Raycasting()
    {
        Debug.DrawLine(raycastPoint.transform.position, Sightendpos.position, Color.green);
        spotted = Physics2D.Linecast(raycastPoint.transform.position, Sightendpos.position, 1 << LayerMask.NameToLayer("Player"));
    }
   void Behaviours()
    {
        if (spotted)
        {
            EnemyAni.SetBool("CanSeePlayer", true);
            speed = 0f;
        }
        else
        {
            EnemyAni.SetBool("CanSeePlayer", false);
            speed = 200f;
        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
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
