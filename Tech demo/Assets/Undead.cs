using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Undead : MonoBehaviour
{
    public Animator ani;
    private GameObject player;
    float time = 10f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Mushroom").gameObject;
    }
    IEnumerator Attack()
    {
        transform.position = player.transform.position;
        ani.SetBool("CanSeePlayer", true);
        yield return new WaitForSeconds(1);
        ani.SetBool("CanSeePlayer", false);
    }
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            time = time - Time.deltaTime;
            if (time<2)
            {
                StartCoroutine(Attack());
            }
            Debug.Log(time);
            if (time<0)
            {
                time = 10f;
            }
        }
    }
}
