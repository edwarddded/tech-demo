using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonGuardianBehaviour : MonoBehaviour
{
    private GameObject player;
    private Health health;
    private Animator anim;
    private GameObject firepoint;

    public GameObject axePrefab;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        firepoint = GameObject.Find("firePoint");
        health = player.GetComponent<Health>();
        anim = GetComponent<Animator>();
        health.health += 1;
        StartCoroutine(Protect());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator Protect()
    {
        for(int i = 0; i < 3; i++)
        {
            health.RestoreHealth(1);
            Instantiate(axePrefab, firepoint.transform.position + new Vector3(0,2,0), firepoint.transform.rotation);
            yield return new WaitForSeconds(2f);
        }
        Destroy(gameObject);
    }
}
