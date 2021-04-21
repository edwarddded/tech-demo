using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class swamp : MonoBehaviour
{
    public Health health;
    public Transform OriginalPoint;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            health.health -= 1;
            collision.gameObject.transform.position = OriginalPoint.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
