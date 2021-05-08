using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPart : MonoBehaviour
{
    public float armHealth;
    private Boss boss;
    public GameObject[] pickups;
    private Transform Portal;

    void Start()
    {
        boss = transform.parent.gameObject.GetComponent<Boss>();
        armHealth = 10f;
        Portal = GameObject.Find("BeginPortal").transform;
    }

    public void TakeDamage(float damage)
    {
        armHealth -= damage;
        boss.TakeDamage(damage);
    }

    void Die()
    {
        int rand = Random.Range(0, 2);
        Instantiate(pickups[rand], Portal.transform.position, Portal.transform.rotation);
    }

}
