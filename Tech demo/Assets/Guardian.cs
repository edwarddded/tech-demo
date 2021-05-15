using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guardian : MonoBehaviour
{
    public GameObject item;

    SpriteRenderer sr;
    public float health = 3f;

    private Rigidbody2D rb;
    public Animator EnemyAni;

    private GameObject raycastPoint;
    public GameObject Player;
    public Transform Sightendpos;
    public bool spotted = false;

    public bool enemyright = true;
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

        }
        else
        {
            EnemyAni.SetBool("CanSeePlayer", false);

        }
    }
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
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
