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
        if (speed >0)
        {
             StartCoroutine(destroy());
        }
       
        
    }
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
        //yield return new WaitForSeconds(2);
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

        BossPart bossPart = col.GetComponent<BossPart>();
        if (bossPart != null)
        {
            bossPart.TakeDamage(2f);
            Destroy(gameObject);
        }

        Boss boss = col.GetComponent<Boss>();
        if (boss != null)
        {
            boss.TakeDamage(2f);
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
        IceBoss iceboss = col.GetComponent<IceBoss>();
        if (iceboss != null)
        {
            iceboss.TakeDamage(2f);
            Destroy(gameObject);
        }

    }
}
