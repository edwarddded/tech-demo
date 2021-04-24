using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private float time = 8f;
    public Animator Ani;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = time - Time.deltaTime;
        Debug.Log(time);
        if (time < 0)
        {
            time = 8f;
        }
        if (time <2.5)
        {
            Ani.SetBool("IsAttack", true);
        }
        else
        {
            Ani.SetBool("IsAttack", false);
        }
        
    }
}
