using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class swamp : MonoBehaviour
{
    
    public Transform OriginalPoint;
    private int playerhealth;
    // Start is called before the first frame update
    void Start()
    {
        playerhealth = GameObject.Find("Player").GetComponent<Health>().health;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerhealth -= 1;
            Debug.Log("Health:" + playerhealth);
            collision.gameObject.transform.position = OriginalPoint.position;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
