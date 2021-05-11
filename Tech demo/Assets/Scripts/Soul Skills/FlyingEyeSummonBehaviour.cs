﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeSummonBehaviour : MonoBehaviour
{
    public float Speed = 10f;
    public Vector3 LaunchOffset;
    private Health health;

    // Start is called before the first frame update
    void Start()
    {
        health = GameObject.Find("Player").GetComponent<Health>();
        var direction = transform.right;
        GetComponent<Rigidbody2D>().AddForce(direction * Speed, ForceMode2D.Impulse);
        transform.Translate(LaunchOffset);
        Destroy(gameObject, 2);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Enemy enemy = col.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(3f);
            health.RestoreHealth(3);
        }
        Boss boss = col.GetComponent<Boss>();
        if (boss != null)
        {
            boss.TakeDamage(3f);
            health.RestoreHealth(3);
        }
        BossPart bossPart = col.GetComponent<BossPart>();
        if (bossPart != null)
        {
            boss.TakeDamage(3f);
            health.RestoreHealth(3);
        }
        FireBoss fireboss = col.GetComponent<FireBoss>();
        if (fireboss != null)
        {
            fireboss.TakeDamage(2f);
            health.RestoreHealth(3);
        }
        Wizard wizard = col.GetComponent<Wizard>();
        if (wizard != null)
        {
            wizard.TakeDamage(2f);
            health.RestoreHealth(3);
        }
    }

}
