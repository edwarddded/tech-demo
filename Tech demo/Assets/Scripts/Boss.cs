using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float BossHealth;
    private float time = 20f;
    public Animator Ani;
    private Transform Portal;
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject FirePortal;

    private PlayerBossSkill playerBossSkill;
    private bool playcanmove;
    private BossHealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
     
        Portal = GameObject.Find("BeginPortal").transform;
        BossHealth = 50f;
        healthBar = GameObject.Find("Healthbar").GetComponent<BossHealthBar>();
        healthBar.setMaxHealth(BossHealth);

        playerBossSkill = GameObject.Find("Player").GetComponent<PlayerBossSkill>();

    }
    
    
    public void TakeDamage(float damage)
    {
        BossHealth -= damage;
        healthBar.SetHealth(BossHealth);
        int rand = Random.Range(1, 4);
        if (BossHealth < 40 && rand == 1)
        {   
            Instantiate(item1, Portal.transform.position, Portal.transform.rotation);
        }else if (BossHealth < 40 && rand == 2)
        {
            Instantiate(item2, Portal.transform.position, Portal.transform.rotation);
        }else if (BossHealth < 40 && rand == 3)
        {
            Instantiate(item3, Portal.transform.position, Portal.transform.rotation);
        }
        if (BossHealth <20 && BossHealth >3)
        {
            SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
            sr.material.color = Color.red;
        }
        if (BossHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        playerBossSkill.skillAvailable = true;
        playerBossSkill.hasForestSkill = true;
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        Destroy(sr);
        //Vector3 fireposition = new Vector3(-20, 20.35f, 0);
        //Instantiate(FirePortal, fireposition, Portal.transform.rotation);
        Ani.SetBool("dialoguePlay", true);
    }
    void SetAttackAnimation()
    {
       
        time = time - Time.deltaTime;
        //Debug.Log(time);
        if (time < 0)
        {
            time = 20f;
        }
        if (time < 2.5)
        {
            Ani.SetBool("IsAttack", true);
        }
        else
        {
            Ani.SetBool("IsAttack", false);
        }
    }
    // Update is called once per frame
    void Update()
    {
            
        SetAttackAnimation();

    }
}
