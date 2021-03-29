using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    private float speed = 3f;
    public float PositionMin;
    public float PositionMax;
    SpriteRenderer sr;
    public float health = 2f;
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            Destroy(collision.gameObject);
            health--;
            if (health == 0)
            {
                Destroy(gameObject);
            }
        }
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
}
