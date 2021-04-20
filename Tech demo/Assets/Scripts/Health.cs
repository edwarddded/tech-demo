using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullHearts;
    public Sprite emptyHearts;

    private int damage = 1;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag =="Enemy")
        {
            Debug.Log(other.gameObject.name);
            health -= damage;
            Debug.Log(health);
        }
      

    }
    // Update is called once per frame
    void Update()
    {
        if (health ==0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHearts;
            }
            else
            {
                hearts[i].sprite = emptyHearts;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
