using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wormFireBall : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health playerhealth = collision.GetComponent<Health>();
        if (playerhealth != null)
        {
            playerhealth.health -= 1;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
