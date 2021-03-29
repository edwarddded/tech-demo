using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 3f;
    public float PositionMin;
    public float PositionMax;

    public GameObject item;

    SpriteRenderer sr;
    public float health = 3f;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
 
    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x>= PositionMax)
        {
            speed = -speed;
            sr.flipX = false;
        }
        else if (transform.position.x <= PositionMin)
        {
            speed = -speed;
            sr.flipX = true;
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
