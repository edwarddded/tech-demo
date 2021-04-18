using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBombBehaviour : MonoBehaviour
{

    public float speed = 4;
    public Vector3 LaunchOffset;
    public bool Thrown;
    private int projectileLives = 3;

    void Start()
    {
        if (Thrown)
        {
            var direction = transform.right + Vector3.up;
            GetComponent<Rigidbody2D>().AddForce(direction * speed, ForceMode2D.Impulse);
        }
        transform.Translate(LaunchOffset);
        Destroy(gameObject, 5);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            projectileLives -= 1;
            enemy.TakeDamage(3f);

            if (projectileLives <= 0)
                Destroy(gameObject);
        }
    }
}
