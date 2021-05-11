using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;

    private bool invincible = false;

    public GameObject fullHearts1, fullhearts2, fullhearts3,fullhearts4;
    public GameObject emptyHearts1, emptyHearts2, emptyHearts3, emptyHearts4;

    private int damage = 1;
    private Vector3 BeginPoint;

    new SpriteRenderer renderer;
    public void Start()
    {
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }
    
    private IEnumerator FlashAfterDamage()
    {
        for (int i = 0; i < 5; i++)
        {
            renderer.material.color = Color.clear;
            yield return new WaitForSeconds(.1f);
            renderer.material.color = Color.white;
            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator Invulnerability()
    {
        invincible = true;
        yield return new WaitForSeconds(2);
        invincible = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!invincible)
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
            if (other.gameObject.tag == "Laser")
            {
                Debug.Log(other.gameObject.name);
                health -= damage;
                Debug.Log(health);
                StartCoroutine(Invulnerability());
                StartCoroutine(FlashAfterDamage());
            }
            if (other.gameObject.tag == "Enemy")
            {
                Debug.Log(other.gameObject.name);
                health -= damage;
                Debug.Log(health);
                StartCoroutine(Invulnerability());
                StartCoroutine(FlashAfterDamage());
            }
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        if (health > 4)
        {
            health = 4;
        }

        if (health == 0)
        {
            SceneManager.LoadScene(6);
            Destroy(gameObject);
        }
        else if(health == 4)
        {
            fullHearts1.gameObject.SetActive(true);
            fullhearts2.gameObject.SetActive(true);
            fullhearts3.gameObject.SetActive(true);
            fullhearts4.gameObject.SetActive(true);
        }
        else if (health == 3)
        {
            fullHearts1.gameObject.SetActive(true);
            fullhearts2.gameObject.SetActive(true);
            fullhearts3.gameObject.SetActive(true);
            fullhearts4.gameObject.SetActive(false);
        }
        else if (health == 2)
        {
            //fullHearts1.gameObject.SetActive(true);
            fullhearts2.gameObject.SetActive(true);
            fullhearts3.gameObject.SetActive(false);
            fullhearts4.gameObject.SetActive(false);
        }
        else if (health ==1)
        {
            fullHearts1.gameObject.SetActive(true);
            fullhearts2.gameObject.SetActive(false);
            fullhearts3.gameObject.SetActive(false);
            fullhearts4.gameObject.SetActive(false);
        }else if (health ==0)
        {
            fullHearts1.gameObject.SetActive(false);
            fullhearts3.gameObject.SetActive(false);
            fullhearts2.gameObject.SetActive(false);
            fullhearts4.gameObject.SetActive(false);
        }
    }

    public void RestoreHealth(int healAmount)
    {
        health += healAmount;
        if(health > 4)
        {
            health = 4;
        }
    }
}
