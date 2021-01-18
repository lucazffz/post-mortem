using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    #region Variables

    //UI elements
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI continueBottonText;
    public Image characterImage;
    
    public Animator animator;

    [HideInInspector] public Interactable interactable;

    [HideInInspector] public bool haveSpoken;
    private bool inConversation;

    private Queue<string> sentences = new Queue<string>();

   

    #endregion

    //enter to continue conversation
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && inConversation) DisplayNextSentence();
    }

    public void StartDialogue(Dialgoue dialogue)
    {
        //can't interact during dialogue
        FindObjectOfType<InteractableManager>().canInteract = false;
        inConversation = true;

        sentences.Clear();

        //UI and animations
        animator.SetBool("isOpen", true);

        characterImage.sprite = dialogue.characterSprite;
        nameText.text = dialogue.name;

        continueBottonText.text = "Continue >>";
        
        //queue story sentence or random sentence
        if(haveSpoken == false)
        {
            foreach (string sentence in dialogue.storySentences) sentences.Enqueue(sentence);
        }
        else
        {
            string sentence = dialogue.randomSentences[Random.Range(0, dialogue.randomSentences.Length)];
            sentences.Enqueue(sentence);
        }

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

        FindObjectOfType<InteractableManager>().canInteract = true;
        inConversation = false;
    }
}
