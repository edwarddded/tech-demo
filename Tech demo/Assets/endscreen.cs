using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endscreen : MonoBehaviour
{
    public Animator endanim;
  
    IEnumerator OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            endanim.SetBool("end", true);
            yield return new WaitForSeconds(15);
          
            SceneManager.LoadSceneAsync(0);
            PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();
            playerController.Destroyall();
        }
    }

}
