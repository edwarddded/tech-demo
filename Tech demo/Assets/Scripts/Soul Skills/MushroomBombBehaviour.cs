using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBombBehaviour : MonoBehaviour
{

    public float speed = 4;
    public Vector3 LaunchOffset;
    public bool Thrown;
    public GameObject explosionEffect;

    void Start()
    {
        if (Thrown)
        {
            var direction = transform.right + Vector3.up;
            GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
        }
        transform.Translate(LaunchOffset);
        Invoke("Explode", 2);
    }

    
    void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(3f);

        }
        Boss boss = collision.collider.GetComponent<Boss>();
        if (boss != null)
        {
            boss.TakeDamage(3f);

        }
    } 

    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, 3f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].CompareTag("Enemy"))
            {
                Enemy enemy = colliders[i].gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(3f);
                }
            }
            if (colliders[i].CompareTag("Boss"))
            {
                Boss boss = colliders[i].gameObject.GetComponent<Boss>();
                if (boss != null)
                {
                    boss.TakeDamage(3f);
                }
                BossPart bossPart = colliders[i].gameObject.GetComponent<BossPart>();
                if (bossPart != null)
                {
                    bossPart.TakeDamage(3f);
                }
            }

        }

        Instantiate(explosionEffect, this.transform.position, this.transform.rotation);

        Destroy(gameObject);
    }
}
