using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireColumnSpell : MonoBehaviour
{
    public float damage = 5f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.5f);
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
        }

        BossPart bossPart = col.GetComponent<BossPart>();
        if (bossPart != null)
        {
            bossPart.TakeDamage(damage);

        }

        Boss boss = col.GetComponent<Boss>();
        if (boss != null)
        {
            boss.TakeDamage(damage);

        }

    }
}
