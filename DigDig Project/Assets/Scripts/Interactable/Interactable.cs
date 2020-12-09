using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    //Variables

    private bool inRange;

    public KeyCode interactKey = KeyCode.F;
    public int eventIndex;
    public UnityEvent interactionEvent;

    void Update()
    {
        //event when interacting
        if (inRange) if (Input.GetKeyDown(interactKey)) interactionEvent.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        inRange = true;

        //UI key and event type sent to Interactable Prompt 
        GameObject.Find("Interactable Prompt").GetComponent<InteractableUI>().interactKey = interactKey;
        GameObject.Find("Interactable Prompt").GetComponent<InteractableUI>().eventIndex = eventIndex;

        //activate UI element
        if (other.CompareTag("Player")) GameObject.Find("Interactable Prompt").GetComponent<InteractableUI>().activatePrompt = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        inRange = false;
        //deactivate UI element
        if (other.CompareTag("Player")) GameObject.Find("Interactable Prompt").GetComponent<InteractableUI>().activatePrompt = false; 
    }
}

  
