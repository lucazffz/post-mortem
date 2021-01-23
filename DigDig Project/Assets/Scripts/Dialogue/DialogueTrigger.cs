using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialgoue dialogue;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.F)) FindObjectOfType<DialogueManager>().NextConversation();
    }

    public void TriggerDialogue()
    {
        

        //start dialogue
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }


}
