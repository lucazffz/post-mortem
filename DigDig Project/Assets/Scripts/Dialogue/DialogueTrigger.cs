using UnityEngine;

public class DialogueTrigger : MonoBehaviour 
{
    public Dialgoue dialogue;

    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    public void NextConversation() {
        dialogue.conversationIndex++;
        dialogue.haveSpokenTo = false;
    }
}