using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screenflash : MonoBehaviour
  
{
    public Animator flashanim;
    IEnumerator OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            flashanim.SetBool("flashing", true);
            yield return new WaitForSeconds(1);
            flashanim.SetBool("flashing", false);
            Destroy(gameObject);

        }
    }
 
}
