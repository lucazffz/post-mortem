using UnityEngine;
using TMPro;


public class InteractableUI : MonoBehaviour
{
    //Variables
    [HideInInspector] public bool activatePrompt;
    [HideInInspector] public KeyCode interactKey;
    
    [HideInInspector] public string[] eventPrompt = {"open", "enter", "unlock"};
    [HideInInspector] public int eventIndex;

    public TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        //Set text elements
        textMeshPro.text = $"Press {interactKey} to {eventPrompt[eventIndex]}";

        //activate and deactivate text
        if (activatePrompt) textMeshPro.enabled = true;
        else textMeshPro.enabled = false;
    }
}
