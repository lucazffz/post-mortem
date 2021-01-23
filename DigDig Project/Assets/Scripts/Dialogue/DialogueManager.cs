using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region Variables

    //UI elements
    public Animator animator;
    public new TextMeshProUGUI name;
    public Image portrait;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI continueButtonText;

    [HideInInspector] public bool inConversaion;
    bool haveSpokenTo;

    //qeueus for text, name and portrait
    Queue<string> sentences = new Queue<string>();
    Queue<string> names = new Queue<string>();
    Queue<Sprite> portraits = new Queue<Sprite>();

    int conversationIndex;
    int sentenceIndex;

    //random num for filler lines
    int newNum = 0;
    int prevNum;
   
    #endregion

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) DisplayNextSentence(); 
    }

    public void StartDialogue(Dialgoue dialogue) {
        //SETUP
        FindObjectOfType<InteractableManager>().canInteract = false;
        inConversaion = true;

        haveSpokenTo = dialogue.haveSpokenTo;
        conversationIndex = dialogue.conversationIndex;
        sentenceIndex = dialogue.sentenceIndex;

        //UI and animations
        animator.SetBool("isOpen", true);
        continueButtonText.text = "Continue >>";

        //QUEUE INFORMATION
        if (haveSpokenTo == false) {
            sentenceIndex = 0;

            //loop trough all sentences in each conversation and add all lines in a queue
            for (int i = 0; i < dialogue.conversations[conversationIndex].sentenceGroups.Length; i++) {
                foreach (string sentence in dialogue.conversations[conversationIndex].sentenceGroups[sentenceIndex].sentences) {
                    sentences.Enqueue(sentence);

                    //add speaker name and portrait in queues
                    names.Enqueue(dialogue.conversations[conversationIndex].sentenceGroups[sentenceIndex].speaker.name);
                    portraits.Enqueue(dialogue.conversations[conversationIndex].sentenceGroups[sentenceIndex].speaker.portrait);
                }
                sentenceIndex++;
            }
        } else {
            //RANDOM FILLER LINES
            name.text = dialogue.interactCharacter.name;
            portrait.sprite = dialogue.interactCharacter.portrait;

            //random num, always different from before
            prevNum = newNum;
            newNum = Random.Range(0, dialogue.fillerLines.Length);
            while (newNum == prevNum) newNum = Random.Range(0, dialogue.fillerLines.Length);
           
            //set sentence to filler lines
            string sentence = dialogue.fillerLines[newNum];
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        dialogue.haveSpokenTo = true;
    }

    public void DisplayNextSentence() {
        //go trough name and portrait queues
        if(haveSpokenTo == false && sentences.Count != 0) {
            name.text = names.Dequeue();
            portrait.sprite = portraits.Dequeue();
        }

        //if 1 or 0 sentences left
        if (sentences.Count == 1) continueButtonText.text = "End Dialogue";
        else if (sentences.Count == 0) {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //type letters
    IEnumerator TypeSentence(string sentence) {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return new WaitForFixedUpdate();
        }
    }

    private void EndDialogue() {
        FindObjectOfType<InteractableManager>().canInteract = true;
        inConversaion = false;

        animator.SetBool("isOpen", false);
    }
}
