using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bulletprefabs;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            shoot();
        }
    }
    void shoot()
    {
        Instantiate(bulletprefabs, firepoint.position, firepoint.rotation);
    }
}
