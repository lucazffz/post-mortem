using UnityEngine;
using TMPro;

public class InteractableManager : MonoBehaviour
{
    public TextMeshProUGUI IinteractText;
    public static bool canInteract;

    [HideInInspector] public static KeyCode interactKey = KeyCode.E;
    [HideInInspector] public static string[] eventPrompt;
    [HideInInspector] public static int eventIndex;

    public void Update() 
    {
        if (PauseMenu.isPaused || DialogueManager.inConversaion || GrabController.holding || !InteractableTrigger.inRange) canInteract = false;
        else canInteract = true;

        if (canInteract) 
        {
            IinteractText.enabled = true;
            IinteractText.text = $"Press {interactKey} to {eventPrompt[eventIndex]}";
        }
        else IinteractText.enabled = false;
    }
}

