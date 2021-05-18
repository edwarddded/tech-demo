using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceGuardianSummonBehaviour : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos;
    private Animator anim;

    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        anim = GetComponent<Animator>();
        StartCoroutine(Die());
    }

    // Update is called once per frame
    void Update()
    {
        playerPos.x = player.transform.position.x+5;
        playerPos.y = player.transform.position.y+1.5f;
        playerPos.z = player.transform.position.z;
        transform.position = playerPos;
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
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(5f);
        anim.SetBool("isDead", true);
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);

    }
}
