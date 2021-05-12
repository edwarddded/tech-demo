using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallShoot : MonoBehaviour
{
    public GameObject fireball;
    public float spawnTime = 2;
    public float spawnDelay = 3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ShootFireball", spawnTime, spawnDelay);
    }

    public void ShootFireball()
    {
        Instantiate(fireball, transform.position, transform.rotation);
    }
    
}
