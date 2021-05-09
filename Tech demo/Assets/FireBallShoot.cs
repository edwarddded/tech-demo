using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallShoot : MonoBehaviour
{
    public GameObject fireball;
    int i = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void shoot()
    {
        
        Instantiate(fireball, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        if (Time.time > i)
        {
            i += 3;
            shoot();
        }
    }
}
