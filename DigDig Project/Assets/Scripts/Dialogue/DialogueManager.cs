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

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI continueBottonText;
    public Image characterImage;

    //player character sprite and name
    public Sprite playerSprite;
    private string playerName = "Player";

    //character name and sprite
    private Sprite characterSprite;
    private string characterName;

    [HideInInspector] public bool haveSpokenTo;
    private bool inConversation;

    private bool playerTalking;

    private Queue<string> sentences = new Queue<string>();

    #endregion

    //enter to continue conversation
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && inConversation) DisplayNextSentence();
    }

    public void StartDialogue(Dialgoue dialogue)
    {
        //can't interact or move during dialogue
        FindObjectOfType<InteractableManager>().canInteract = false;
        FindObjectOfType<PlayerBehavior>().canMove = false;

        //decides if player or character starts talking
        if (dialogue.playerStartTalking == true) playerTalking = false;
        else playerTalking = true;
        
        inConversation = true;

        sentences.Clear();

        //UI and animations
        animator.SetBool("isOpen", true);

        characterSprite = dialogue.characterSprite;
        characterImage.sprite = characterSprite;

        characterName = dialogue.name;
        nameText.text = characterName;

        continueBottonText.text = "Continue >>";
        
        //queue story sentence or random sentence
        if(haveSpokenTo == false)
        {
            foreach (string sentence in dialogue.sentences) sentences.Enqueue(sentence);
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
        //Alternate between player and character name and image
        if (haveSpokenTo == false && sentences.Count != 0)
        {
            if (playerTalking == true) playerTalking = false;
            else if (playerTalking == false) playerTalking = true;

            if (playerTalking == true)
            {
                characterImage.sprite = playerSprite;
                nameText.text = playerName;
            }
            else
            {
                characterImage.sprite = characterSprite;
                nameText.text = characterName;
            }    
        }
        
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
        FindObjectOfType<PlayerBehavior>().canMove = true;

        inConversation = false;
    }
}
