using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Enemy enemy = col.GetComponent<Enemy>();
        if(enemy != null)
        {
            enemy.TakeDamage(1f);
            Destroy(gameObject);
        }

        Boss boss = col.GetComponent<Boss>();
        if (boss)
        {
            boss.TakeDamage(2f);
            Destroy(gameObject);

            Debug.Log(boss.BossHealth);
        }

    }
}
