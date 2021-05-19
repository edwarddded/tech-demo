﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBombBehaviour : MonoBehaviour
{

    public float speed = 7f;
    public Vector3 LaunchOffset;
    public bool Thrown;
    public GameObject explosionEffect;
    public GameObject miniMushrooomBombPrefab;

    void Start()
    {
        if (Thrown)
        {
            var direction = transform.right + Vector3.up;
            GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
        }
        //transform.Translate(LaunchOffset);
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
        BossPart bossPart = collision.collider.GetComponent<BossPart>();
        if (bossPart != null)
        {
            bossPart.TakeDamage(3f);

        }
        FireBoss fireboss = collision.collider.GetComponent<FireBoss>();
        if (fireboss != null)
        {
            fireboss.TakeDamage(3f); 
        }
        Wizard wizard = collision.collider.GetComponent<Wizard>();
        if (wizard != null)
        {
            wizard.TakeDamage(3f);
        }
        IceBoss iceboss = collision.collider.GetComponent<IceBoss>();
        if (iceboss != null)
        {
            iceboss.TakeDamage(3f);

        }
    } 

    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, 2f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].CompareTag("Enemy"))
            {
                Enemy enemy = colliders[i].gameObject.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(3f);
                }
                Wizard wizard = colliders[i].gameObject.GetComponent<Wizard>();
                if (wizard != null)
                {
                    wizard.TakeDamage(3f);
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
                FireBoss fireboss = colliders[i].gameObject.GetComponent<FireBoss>();
                if (fireboss != null)
                {
                    fireboss.TakeDamage(3f);
                }
                IceBoss iceboss = colliders[i].gameObject.GetComponent<IceBoss>();
                if (iceboss !=null)
                {
                    iceboss.TakeDamage(3f);
                }
            }

        }

        Instantiate(explosionEffect, this.transform.position, this.transform.rotation);
        Instantiate(miniMushrooomBombPrefab, this.transform.position, this.transform.rotation);
        Instantiate(miniMushrooomBombPrefab, this.transform.position, this.transform.rotation * Quaternion.Euler(0, 0, 45));
        Instantiate(miniMushrooomBombPrefab, this.transform.position, this.transform.rotation * Quaternion.Euler(0, 0, 90));
        Instantiate(miniMushrooomBombPrefab, this.transform.position, this.transform.rotation * Quaternion.Euler(0, 0, 135));
        Instantiate(miniMushrooomBombPrefab, this.transform.position, this.transform.rotation * Quaternion.Euler(0, 0, 180));
        Instantiate(miniMushrooomBombPrefab, this.transform.position, this.transform.rotation * Quaternion.Euler(0, 0, 225));
        Instantiate(miniMushrooomBombPrefab, this.transform.position, this.transform.rotation * Quaternion.Euler(0, 0, 270));
        Instantiate(miniMushrooomBombPrefab, this.transform.position, this.transform.rotation * Quaternion.Euler(0, 0, 315));

        Destroy(gameObject);
    }
}
