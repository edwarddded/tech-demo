using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeSummonBehaviour : MonoBehaviour
{
    public float Speed = 10f;
    

    // Start is called before the first frame update
    void Start()
    {
        var direction = GameObject.FindWithTag("Player").transform.right;
        GetComponent<Rigidbody2D>().AddForce(direction * Speed, ForceMode2D.Impulse);
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        //var direction = transform.right;
        // GetComponent<Rigidbody2D>().AddForce(direction * Speed, ForceMode2D.Force);
        // transform.position += -transform.right * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Enemy enemy = col.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(3f);
            Destroy(gameObject);
        }
    }

}
