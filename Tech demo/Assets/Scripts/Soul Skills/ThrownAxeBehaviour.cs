using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownAxeBehaviour : MonoBehaviour
{
    public float speed = 15f;
    public float damage = 5f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Enemy enemy = col.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            Destroy(gameObject);
        }

        BossPart bossPart = col.GetComponent<BossPart>();
        if (bossPart != null)
        {
            bossPart.TakeDamage(damage);
            Destroy(gameObject);

        }

        Boss boss = col.GetComponent<Boss>();
        if (boss != null)
        {
            boss.TakeDamage(damage);
            Destroy(gameObject);

        }
        FireBoss fireboss = col.GetComponent<FireBoss>();
        if (fireboss != null)
        {
            fireboss.TakeDamage(2f);
            Destroy(gameObject);
        }
        Wizard wizard = col.GetComponent<Wizard>();
        if (wizard != null)
        {
            wizard.TakeDamage(2f);
            Destroy(gameObject);
        }

    }
}
