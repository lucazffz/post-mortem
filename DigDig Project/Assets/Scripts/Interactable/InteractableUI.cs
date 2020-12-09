using UnityEngine;
using TMPro;

public class InteractableUI : MonoBehaviour
{
    //Variables
    [HideInInspector] public bool activatePrompt = false;
    [HideInInspector] public KeyCode interactKey;

    [HideInInspector] public string[] eventPrompt;
    [HideInInspector] public int eventIndex;
    
    private TextMeshProUGUI textMeshPro;    

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        //activate and deactivate text and set elements
        if (activatePrompt)
        {
            textMeshPro.text = $"Press {interactKey} to {eventPrompt[eventIndex]}";
            textMeshPro.enabled = true;
        }
        else textMeshPro.enabled = false;
    }
}
