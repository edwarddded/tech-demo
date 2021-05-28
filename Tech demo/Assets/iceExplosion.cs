using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceExplosion : MonoBehaviour
{
    private IceBoss iceboss;
     Animator Animator;
    public bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        iceboss = GameObject.Find("IceBoss").GetComponent<IceBoss>();
        Animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (iceboss.time < 2.5)
        {
            Animator.SetBool("IsIceExplosion", true);
        }
        else
        {
            Animator.SetBool("IsIceExplosion", false);
        }
        if (!canMove) // freezing attack
        {
           
            Animator.SetBool("hasStopped", true);

            return;

        }
        else
        {
            Animator.SetBool("hasStopped", false);
        }
    }
}
