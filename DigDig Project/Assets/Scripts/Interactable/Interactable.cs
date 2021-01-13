using UnityEngine;
using UnityEngine.Events;
using UnityEditor;

public class Interactable : MonoBehaviour
{
    //Variables

    private bool inRange;

    public UnityEvent interactionEvent;

    public KeyCode interactKey = KeyCode.E;

    [HideInInspector] public int eventIndex = 0;
    [HideInInspector] public string[] eventPrompt = new string[] { "open", "unlock", "enter", "talk", "pick up", "read" };
    
    void Update()
    {
        //event when interacting
        if (inRange && Input.GetKeyDown(interactKey)) interactionEvent.Invoke();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        inRange = true;

        //UI key and event type sent to Interactable Prompt 
        GameObject.Find("Interactable Prompt").GetComponent<InteractableUI>().interactKey = interactKey;
        GameObject.Find("Interactable Prompt").GetComponent<InteractableUI>().eventIndex = eventIndex;
        GameObject.Find("Interactable Prompt").GetComponent<InteractableUI>().eventPrompt = eventPrompt;

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

// Custom drop down eventPrompt menu
[CustomEditor(typeof(Interactable))]
public class DropDownEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Interactable script = (Interactable)target;

        GUIContent arrayLabel = new GUIContent("Event Type");
        script.eventIndex = EditorGUILayout.Popup(arrayLabel, script.eventIndex, script.eventPrompt);

        EditorUtility.SetDirty(target);
    }
}

