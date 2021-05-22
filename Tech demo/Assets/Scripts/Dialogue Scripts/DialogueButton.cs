using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    public DialogueBase dialogue;
 public void getNextLine()
    {
        DialogueManager.instance.DequeueDialogue();
    }
    public void skipText()
    {
        DialogueManager.instance.endOfDialogue();
    }
  
}
