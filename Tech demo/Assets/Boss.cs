using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float BossHealth;
    private float time = 8f;
    public Animator Ani;
    private Transform Portal;
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

 

    private BossHealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
     
        Portal = GameObject.Find("BeginPoint").transform;
        BossHealth = 50f;
        healthBar = GameObject.Find("Healthbar").GetComponent<BossHealthBar>();
        healthBar.setMaxHealth(BossHealth);
        
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
        if (BossHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Instantiate(item, gameObject.transform.position, gameObject.transform.rotation);
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
        Destroy(sr);
        Ani.SetBool("dialoguePlay", true);
    }
    void SetAttackAnimation()
    {
       
        time = time - Time.deltaTime;
        //Debug.Log(time);
        if (time < 0)
        {
            time = 8f;
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
