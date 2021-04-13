using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region Variables

    public Animator animator;
    public TextMeshProUGUI Iname;
    public Image Iportrait;
    public TextMeshProUGUI IdialogueText;
    public TextMeshProUGUI IcontinueButtonText;

    public static bool inConversaion;
    bool haveSpokenTo;

    Queue<string> sentences = new Queue<string>();
    Queue<string> names = new Queue<string>();
    Queue<Sprite> portraits = new Queue<Sprite>();

    int conversationIndex;
    int sentenceIndex;

    int randomNewNum = 0;
    int randomPrevNum;
   
    #endregion

    private void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Return) && inConversaion && !PauseMenu.pauseMenuActivated) DisplayNextSentence(); 
    }

    public void StartDialogue(Dialgoue dialogue) 
    {
        inConversaion = true;

        haveSpokenTo = dialogue.haveSpokenTo;
        conversationIndex = dialogue.conversationIndex;
        sentenceIndex = dialogue.sentenceIndex;

        animator.SetBool("isOpen", true);
        IcontinueButtonText.text = "Continue >>";
        FindObjectOfType<AudioManager>().PlaySound("Swosh");

        if (haveSpokenTo == false) 
        {
            sentenceIndex = 0;

            //loop trough all sentences in each conversation and add all lines in a queue
            for (int i = 0; i < dialogue.conversations[conversationIndex].sentenceGroups.Length; i++) 
            {
                foreach (string sentence in dialogue.conversations[conversationIndex].sentenceGroups[sentenceIndex].sentences) 
                {
                    sentences.Enqueue(sentence);

                    //add speaker name and portrait in queues
                    names.Enqueue(dialogue.conversations[conversationIndex].sentenceGroups[sentenceIndex].speaker.name);
                    portraits.Enqueue(dialogue.conversations[conversationIndex].sentenceGroups[sentenceIndex].speaker.portrait);
                }

                sentenceIndex++;
            }
        } 
        else 
        {
            //random filler lines
            Iname.text = dialogue.interactCharacter.name;
            Iportrait.sprite = dialogue.interactCharacter.portrait;

            randomPrevNum = randomNewNum;
            randomNewNum = Random.Range(0, dialogue.fillerLines.Length);
            while (randomNewNum == randomPrevNum) randomNewNum = Random.Range(0, dialogue.fillerLines.Length);
           
            string sentence = dialogue.fillerLines[randomNewNum];
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
        dialogue.haveSpokenTo = true;
    }

    public void DisplayNextSentence() 
    {
        if(haveSpokenTo == false && sentences.Count != 0) 
        {
            Iname.text = names.Dequeue();
            Iportrait.sprite = portraits.Dequeue();
        }

        if (sentences.Count == 1) IcontinueButtonText.text = "End >>";
        else if (sentences.Count == 0) 
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //type letters
    IEnumerator TypeSentence(string sentence) 
    {
        IdialogueText.text = "";

        foreach (char letter in sentence.ToCharArray()) 
        {
            IdialogueText.text += letter;
            FindObjectOfType<AudioManager>().PlaySound("Typewriter");

            yield return new WaitForSeconds(0.07f);
        }
    }

    private void EndDialogue()
    {
        inConversaion = false;
        animator.SetBool("isOpen", false);
        StopAllCoroutines();

        FindObjectOfType<AudioManager>().PlaySound("Swosh");
    }
}
