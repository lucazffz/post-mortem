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

    public TextMeshProUGUI UIname;
    public TextMeshProUGUI UIdialogueText;
    public TextMeshProUGUI UIcontinueButtonText;
    public Image UIportrait;


  

    [HideInInspector] public bool haveSpokenTo;

    public bool inConversaion;
  
   

    private Queue<string> sentences = new Queue<string>();
    private Queue<string> names = new Queue<string>();
    private Queue<Sprite> portraits = new Queue<Sprite>();

    private int conversationIndex = 0;
    private int sentenceIndex = 0;

    
    #endregion

    //enter to continue conversation
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) DisplayNextSentence();
    }

    public void StartDialogue(Dialgoue dialogue)
    {
        inConversaion = true;

        sentences.Clear();
        names.Clear();
        portraits.Clear();

        //UI and animations
        animator.SetBool("isOpen", true);

        UIcontinueButtonText.text = "Continue >>";

        //queue story sentence or random sentence
        if (haveSpokenTo == false)
        {
            sentenceIndex = 0;

            foreach (var sentence in dialogue.conversations[conversationIndex].sentences)
            {
                foreach (string line in dialogue.conversations[conversationIndex].sentences[sentenceIndex].lines)
                {
                    if (sentenceIndex % 2 == 0)
                    {
                        names.Enqueue(dialogue.player.fullName);
                        portraits.Enqueue(dialogue.player.portrait);
                    } 
                    else
                    {
                        names.Enqueue(dialogue.character.fullName);
                        portraits.Enqueue(dialogue.character.portrait);
                    }
                    
                    sentences.Enqueue(line);
                }
                sentenceIndex++;
            }
        }
        else
        {
            sentences.Clear();

            UIname.text = dialogue.character.fullName;
            UIportrait.sprite = dialogue.character.portrait;
           
            string sentence = dialogue.fillerLines[Random.Range(0, dialogue.fillerLines.Length)];
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
         
    }

    public void DisplayNextSentence()
    {
        if(haveSpokenTo == false && sentences.Count != 0)
        {
            UIname.text = names.Dequeue();
            UIportrait.sprite = portraits.Dequeue();
        }

        //if no sentences left
        if (sentences.Count == 0)
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
        UIdialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            UIdialogueText.text += letter;
            yield return null;
        }
    }

    public void NextConversation()
    {
        conversationIndex++;
        haveSpokenTo = false;
    }

    private void EndDialogue() 
    {
        inConversaion = false;

        animator.SetBool("isOpen", false);
        haveSpokenTo = true;
    }
}
