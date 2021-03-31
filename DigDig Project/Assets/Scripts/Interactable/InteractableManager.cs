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
        Iinteractable.transform.GetChild(0).transform.position = promptPosition;

        //needs to be re-worked
        if (PauseMenu.pauseMenuActivated || DialogueManager.inConversaion || LanternController.holdingLantern  || InventoryManager.instance.inventoryActivated ||!InteractableTrigger.staticInRange && !LanternController.canHoldLantern && !GrabController.canGrab || !PlayerBehavior.isGrounded || PlayerBehavior.isClimbing) canInteract = false;
        else canInteract = true;

        if (canInteract)
        {
            Iinteractable.enabled = true;
            IinteractText.text = $"[{interactKey}] {eventPrompt[eventIndex]}";
        }
        else Iinteractable.enabled = false;
    }
}

