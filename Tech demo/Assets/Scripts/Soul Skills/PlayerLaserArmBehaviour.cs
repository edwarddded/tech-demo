using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaserArmBehaviour : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Enemy enemy = col.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(10f);
        }
        Boss boss = col.GetComponent<Boss>();
        if (boss != null)
        {
            boss.TakeDamage(10f);
        }
        BossPart bossPart = col.GetComponent<BossPart>();
        if (bossPart != null)
        {
            boss.TakeDamage(10f);
        }
        FireBoss fireboss = col.GetComponent<FireBoss>();
        if (fireboss != null)
        {
            fireboss.TakeDamage(10f);
        }
        Wizard wizard = col.GetComponent<Wizard>();
        if (wizard != null)
        {
            wizard.TakeDamage(10f);
        }
    }
}
