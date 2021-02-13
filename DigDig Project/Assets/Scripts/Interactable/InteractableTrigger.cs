using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

public class InteractableTrigger : MonoBehaviour
{
    [HideInInspector] public int eventIndex = 0;
    [HideInInspector] public string[] eventPrompt = new string[] { "open", "unlock", "enter", "talk", "pick up", "read" };
    [HideInInspector] public static bool inRange;

    public UnityEvent interactionEvent;

    private void Update () 
    {
        if (Input.GetKeyDown(InteractableManager.interactKey) 
            && InteractableManager.canInteract && inRange) interactionEvent.Invoke();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;

            InteractableManager.eventPrompt = eventPrompt;
            InteractableManager.eventIndex = eventIndex;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}

#region UI element

// Custom drop down eventPrompt menu
[CustomEditor(typeof(InteractableTrigger))]
public class DropDownEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        InteractableTrigger script = (InteractableTrigger)target;

        GUIContent arrayLabel = new GUIContent("Event Type");
        script.eventIndex = EditorGUILayout.Popup(arrayLabel, script.eventIndex, script.eventPrompt);

        EditorUtility.SetDirty(target);
    }
}

#endregion