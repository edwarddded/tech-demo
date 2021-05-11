using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRoomFireBall : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.up  * speed;
        if (speed>0)
        {
            StartCoroutine(destroy());   
        }
    }
    IEnumerator destroy()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
