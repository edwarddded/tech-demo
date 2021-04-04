using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillDictionary : MonoBehaviour
{
    public Transform firepoint;

    public GameObject iceShotPrefab;
    public GameObject combustPrefab;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ActivateAbility(int abilityIndex) {

        if (abilityIndex == 1)
            IceShot();
        if (abilityIndex == 2)
            Combust();
    }

    //Below is the collection of all the player skills

    // #1 Ice Shot
    void IceShot()
    {
        Debug.Log("Ability 1 Activated");
        Instantiate(iceShotPrefab, firepoint.position, firepoint.rotation);
    }

    // #2 
    void Combust()
    {
        Debug.Log("Ability 2 Activated");

        Instantiate(combustPrefab, this.transform.position, this.transform.rotation);

        Collider2D[] colliders = Physics2D.OverlapCircleAll(this.transform.position, 2f);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].CompareTag("Enemy"))
            {
                Enemy enemy = colliders[i].gameObject.GetComponent<Enemy>();
                if(enemy != null)
                {
                    enemy.TakeDamage(3f);
                }
            }
        }
       
    }
}
