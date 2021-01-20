using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialgoue dialogue;

    private bool haveSpoken;

    public void TriggerDialogue()
    {
        //have had conversation with or not
        if(haveSpoken == true) FindObjectOfType<DialogueManager>().haveSpokenTo = true;
        else FindObjectOfType<DialogueManager>().haveSpokenTo = false;

        haveSpoken = true;

        //start dialogue
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
