﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private Animator bossani;
    private GameObject Boss;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("error" + gameObject.name);
        }
        else
        {
            instance = this;
        }
    }
    private void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
        
    }

    public GameObject dialogueBox;
    public Text dialogueName;
    public Text dialogueText;
    public Image dialoguePortrait;
    public float delay = 0.001f;
    public bool isCurrentlyTyping;
    private string completeText;
    private PlayerController thePlayer;
 


    public Queue<DialogueBase.Info> dialogueInfo = new Queue<DialogueBase.Info>();
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            DequeueDialogue();
        }
    }

    public void EnqueueDialogue (DialogueBase db)
    {
   
        dialogueBox.SetActive(true);
        thePlayer.canMove = false;
        
       
        

        dialogueInfo.Clear();
        foreach (DialogueBase.Info info in db.dialogueinfo)
        {
            dialogueInfo.Enqueue(info);
            

        }

         DequeueDialogue();
        Time.timeScale = 0;
    }

    public void DequeueDialogue()
    {
        if (dialogueInfo.Count == 0)
        {
            endOfDialogue();
            return;
        }
        if (isCurrentlyTyping == true)
        {
            CompleteText();
            StopAllCoroutines();
            isCurrentlyTyping = false;
            return;
        }
        DialogueBase.Info info = dialogueInfo.Dequeue();
        completeText = info.myText;
        dialogueName.text = info.myName;
        dialogueText.text = info.myText;
        dialoguePortrait.sprite = info.portrait;
        dialogueText.text = "";
        StartCoroutine(TypeText(info));
    }

    IEnumerator TypeText(DialogueBase.Info info)
    {
        isCurrentlyTyping = true;
        
        foreach (char c in info.myText.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueText.text += c;
            
        }
        isCurrentlyTyping = false;
      

    }
    public void EnqueueAutoPlay(DialogueBase db)
    {

        dialogueBox.SetActive(true);
        thePlayer.canMove = false;
       


        dialogueInfo.Clear();
        foreach (DialogueBase.Info info in db.dialogueinfo)
        {
            dialogueInfo.Enqueue(info);


        }

        DequeueAutoPlay();
    }

    public void DequeueAutoPlay()
    {
        if (dialogueInfo.Count == 0)
        {
            endOfDialogue();
            return;
        }
        if (isCurrentlyTyping == true)
        {
            CompleteText();
            StopAllCoroutines();
            isCurrentlyTyping = false;
            return;
        }
        DialogueBase.Info info = dialogueInfo.Dequeue();
        completeText = info.myText;
        dialogueName.text = info.myName;
        dialogueText.text = info.myText;
        dialoguePortrait.sprite = info.portrait;
        dialogueText.text = "";
        StartCoroutine(AutoPlay(info));
    }

    IEnumerator AutoPlay(DialogueBase.Info info)
    {
        isCurrentlyTyping = true;

        foreach (char c in info.myText.ToCharArray())
        {
            yield return new WaitForSeconds(delay);
            dialogueText.text += c;

        }
        isCurrentlyTyping = false;
        yield return new WaitForSeconds(1);

        DequeueAutoPlay();

    }

    private void CompleteText()
    {
        dialogueText.text = completeText;
    }
    public void endOfDialogue()
    {
        dialogueBox.SetActive(false);
        thePlayer.canMove = true;
        Time.timeScale = 1;
        if (bossani != null)
        {
            bossani.SetBool("dialoguePlay", false);
        }
 
        
    }
  
}
