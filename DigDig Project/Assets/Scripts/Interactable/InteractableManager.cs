using UnityEngine;
using TMPro;

public class InteractableManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

     public bool canInteract;
    [HideInInspector] public KeyCode interactKey;
    [HideInInspector] public string[] eventPrompt;
    [HideInInspector] public int eventIndex;



    public void Update()
    {
        if (FindObjectOfType<DialogueManager>().inConversaion == true) canInteract = false;
        else if (FindObjectOfType<DialogueManager>().inConversaion == false) canInteract = true;

        if (canInteract == true)
        {
            textMeshPro.enabled = true;
            textMeshPro.text = $"Press {interactKey} to {eventPrompt[eventIndex]}";
        }
        else if(canInteract == false) textMeshPro.enabled = false;





    }
}

