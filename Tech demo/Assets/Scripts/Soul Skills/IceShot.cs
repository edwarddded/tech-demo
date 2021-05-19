using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShot : MonoBehaviour
{
    public float speed = 7f;
    public Rigidbody2D rb;
    private int projectileLives = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        Destroy(gameObject, 3);
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
            projectileLives -= 1;
            enemy.TakeDamage(3f);

            if(projectileLives <= 0)
            Destroy(gameObject);
        }
        Boss boss = col.GetComponent<Boss>();
        if (boss != null)
        {
            projectileLives -= 1;
            boss.TakeDamage(3f);

            if (projectileLives <= 0)
                Destroy(gameObject);
        }
        BossPart bossPart = col.GetComponent<BossPart>();
        if (bossPart != null)
        {
            projectileLives -= 1;
            boss.TakeDamage(3f);

            if (projectileLives <= 0)
                Destroy(gameObject);
        }
        FireBoss fireboss = col.GetComponent<FireBoss>();
        if (fireboss != null)
        {
            projectileLives -= 1;
            fireboss.TakeDamage(3f);

            if (projectileLives <= 0)
                Destroy(gameObject);

        }
        Wizard wizard = col.GetComponent<Wizard>();
        if (wizard != null)
        {
            projectileLives -= 1;
            wizard.TakeDamage(3f);

            if (projectileLives <= 0)
                Destroy(gameObject);

        }
        IceBoss iceboss = col.GetComponent<IceBoss>();
        if (iceboss != null)
        {
            projectileLives -= 1;
            iceboss.TakeDamage(3f);

            if (projectileLives <= 0)
                Destroy(gameObject);
        }
    }
}
