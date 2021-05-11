using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPart : MonoBehaviour
{
    public float bossPartHealth;
    public GameObject[] pickups;
    public bool hasPickups;

    private Boss boss;
    private Transform Portal;

    void Start()
    {
        boss = (Boss) GameObject.Find("ForestBoss2").GetComponent<Boss>();
        Portal = GameObject.Find("BeginPortal").transform;
    }

    public void TakeDamage(float damage)
    {
        float damageToBoss = damage;

        if((bossPartHealth - damage) < 0)
        {
            damageToBoss = damage + (bossPartHealth - damage);
        }

        if(bossPartHealth > 0)
        bossPartHealth -= damage;

        if(boss != null)
        boss.TakeDamage(damageToBoss);

        if (bossPartHealth <= 0)
            Die();
    }

    void Die()
    {
        if (hasPickups)
        {
            int rand = Random.Range(0, pickups.Length - 1);
            Instantiate(pickups[rand], Portal.transform.position, Portal.transform.rotation);
        }

        Destroy(gameObject);
    }

}
