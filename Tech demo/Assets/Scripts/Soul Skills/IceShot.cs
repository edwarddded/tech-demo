using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceShot : MonoBehaviour
{
    public float speed = 7f;
    public Rigidbody2D rb;
    private int projectileLives = 3;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Enemy enemy = col.GetComponent<Enemy>();
        if (enemy != null)
        {
            projectileLives -= 1;
            enemy.TakeDamage(3f);

            if(projectileLives <= 0)
            Destroy(gameObject);
        }

    }
}
