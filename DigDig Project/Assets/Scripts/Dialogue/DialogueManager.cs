using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI continueBottonText;

    public Animator animator;

    [HideInInspector]
    public bool haveSpoken = false;

    private Queue<string> sentences;


    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialgoue dialogue)
    {
        animator.SetBool("isOpen", true);

        sentences.Clear();

        nameText.text = dialogue.name;
        continueBottonText.text = "Continue >>";
        

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
   
    public void DisplayNextSentence()
    {
        if (sentences.Count == 1) continueBottonText.text = "End Dialogue >>";

        if(sentences.Count == 0)
        {
            EndDialogue();

            return;
        }
       
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            

            dialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        animator.SetBool("isOpen", false);
    }
    


}
