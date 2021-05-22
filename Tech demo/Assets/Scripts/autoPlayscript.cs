using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class autoPlayscript : MonoBehaviour
{
    public DialogueBase dialogue;
    public GameObject speechBubble;

    public void TriggerDialogue()
    {
        DialogueManager.instance.EnqueueAutoPlay(dialogue);


    }
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            TriggerDialogue();
            Object.Destroy(gameObject);
            Object.Destroy(speechBubble);
        }

    }

}
