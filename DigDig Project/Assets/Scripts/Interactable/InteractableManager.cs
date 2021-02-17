using UnityEngine;
using TMPro;

public class InteractableManager : MonoBehaviour
{
    public GameObject player;
    public Canvas Iinteractable;
    public TextMeshProUGUI IinteractText;

    public float xOffset;
    public float yOffset;

    public static bool canInteract;

    [HideInInspector] public static KeyCode interactKey = KeyCode.E;
    [HideInInspector] public static string[] eventPrompt;
    [HideInInspector] public static int eventIndex;

    public void Update() 
    {
        Vector2 promptPosition = Camera.main.WorldToScreenPoint(player.transform.position) + new Vector3(xOffset, yOffset);
        Iinteractable.transform.position = promptPosition;

        //needs to be re-worked
        if (PauseMenu.isPaused || DialogueManager.inConversaion || GrabController.holding || !InteractableTrigger.staticInRange) canInteract = false;
        else canInteract = true;

        if (canInteract)
        {
            Iinteractable.enabled = true;
            IinteractText.text = $"Press {interactKey} to {eventPrompt[eventIndex]}";
        }
        else Iinteractable.enabled = false;
    }
}

