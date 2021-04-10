using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 200f;
    public float PositionMin;
    public float PositionMax;

    public GameObject item;

    SpriteRenderer sr;
    public float health = 3f;

    private Rigidbody2D rb;
 

    
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        
    }
 
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
        if (rb.position.x > PositionMax)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            speed *= -1;
            rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
        }else if (rb.position.x < PositionMin)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            speed *= -1;
            rb.velocity = new Vector2(speed * Time.fixedDeltaTime, rb.velocity.y);
        }
    }
   
  
    public void TakeDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Instantiate(item, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);    
    }
}
