using UnityEngine;
using UnityEditor;
using UnityEngine.Events;

public class InteractableTrigger : MonoBehaviour
{
    public bool autoTrigger;

    [HideInInspector] public int eventIndex = 0;
    [HideInInspector] public string[] eventPrompt = new string[] { "open", "unlock", "enter", "talk", "pick up", "read", "hold", "climb up", "climb down", "push/pull" };
    [HideInInspector] public bool inRange;

    public static bool staticInRange;

    public UnityEvent interactionEvent;

    private void Update () 
    {
        if (Input.GetKeyDown(InteractableManager.interactKey) && InteractableManager.canInteract && inRange && !autoTrigger) interactionEvent.Invoke();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!autoTrigger)
            {
                inRange = true;
                staticInRange = true;
             
                InteractableManager.eventPrompt = eventPrompt;
                InteractableManager.eventIndex = eventIndex;
            }
            else
            {
                interactionEvent.Invoke();
                Destroy(gameObject);
            }
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            inRange = false;
            staticInRange = false;
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