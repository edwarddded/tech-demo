using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;

    public GameObject fullHearts1, fullhearts2, fullhearts3,fullhearts4;
    public GameObject emptyHearts1, emptyHearts2, emptyHearts3, emptyHearts4;

    private int damage = 1;
    private Vector3 BeginPoint;

    public void Start()
    {
       
    }
    //need to improve
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag =="Enemy")
        {
            Debug.Log(other.gameObject.name);
            health -= damage;
            Debug.Log(health);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "swamp")
        {
            BeginPoint = GameObject.Find("BeginPortal").transform.position;
            Debug.Log(BeginPoint);
            Debug.Log(other.gameObject.name);
            health -= damage;
            Debug.Log(health);
            gameObject.transform.position = BeginPoint;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            SceneManager.LoadScene(5);
            Destroy(gameObject);
        }
        else if (health == 3)
        {
            fullhearts4.gameObject.SetActive(false);
        }
        else if (health == 2)
        {
            fullhearts4.gameObject.SetActive(false);
            fullhearts3.gameObject.SetActive(false);
        }
        else if (health ==1)
        {
            fullhearts3.gameObject.SetActive(false);
            fullhearts2.gameObject.SetActive(false);
            fullhearts4.gameObject.SetActive(false);
        }else if (health ==0)
        {
            fullHearts1.gameObject.SetActive(false);
            fullhearts3.gameObject.SetActive(false);
            fullhearts2.gameObject.SetActive(false);
            fullhearts4.gameObject.SetActive(false);
        }
    }
}
