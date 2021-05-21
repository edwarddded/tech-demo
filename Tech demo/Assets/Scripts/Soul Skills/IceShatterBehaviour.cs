using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShatterBehaviour : MonoBehaviour
{
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Enemy enemy = col.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Boss boss = col.GetComponent<Boss>();
        if (boss != null)
        {
            boss.TakeDamage(damage);
        }
        BossPart bossPart = col.GetComponent<BossPart>();
        if (bossPart != null)
        {
            bossPart.TakeDamage(damage);
        }
        FireBoss fireboss = col.GetComponent<FireBoss>();
        if (fireboss != null)
        {
            fireboss.TakeDamage(damage);
        }
        Wizard wizard = col.GetComponent<Wizard>();
        if (wizard != null)
        {
            wizard.TakeDamage(damage);
        }
        IceBoss iceboss = col.GetComponent<IceBoss>();
        if (iceboss != null)
        {
            iceboss.TakeDamage(damage);
        }
    }
}
