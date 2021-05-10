using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMushroomBomb : MonoBehaviour
{
    public float damage = 3f;
    public float speed = 3f;
    public Vector3 LaunchOffset;
    public bool Thrown;

    // Start is called before the first frame update
    void Start()
    {
        if (Thrown)
        {
            var direction = transform.right + Vector3.up;
            GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
        }
        transform.Translate(LaunchOffset);

        Destroy(gameObject, 2);
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

    }
}

