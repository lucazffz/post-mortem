using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region Variables

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI continueBottonText;
    public Image characterImage;
    

    public Animator animator;

    private Queue<string> sentences;

    #endregion

    void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialgoue dialogue)
    {
        sentences.Clear();
        animator.SetBool("isOpen", true);

        //name and image
        characterImage.sprite = dialogue.characterSprite;
        nameText.text = dialogue.name;

        continueBottonText.text = "Continue >>";
        
        //queue sentence
        foreach (string sentence in dialogue.sentences) sentences.Enqueue(sentence);

        DisplayNextSentence();
    }
   
    public void DisplayNextSentence()
    {
        if (sentences.Count == 1) continueBottonText.text = "End Dialogue >>";

        //if no sentences left
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
       
        string sentence = sentences.Dequeue();

        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    //show letter one by one
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
