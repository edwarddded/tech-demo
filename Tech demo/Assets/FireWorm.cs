using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWorm : MonoBehaviour
{
    public Transform firepoint;
    public GameObject fireball;
    int i = 2;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        bool canseeplayer = gameObject.GetComponent<Enemy>().spotted;
        if (canseeplayer == true)
        {   
           
            if (Time.time >i)
            {
                i += 3;
                shoot();
            }
        }
    }
    void shoot()
    {
        
        Instantiate(fireball, firepoint.position, firepoint.rotation);
        
    }
        
    
}
