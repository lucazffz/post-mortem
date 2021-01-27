using UnityEngine;
using TMPro;

public class InteractableManager : MonoBehaviour
{
    public TextMeshProUGUI IinteractText;
    public bool canInteract;

    [HideInInspector] public KeyCode interactKey;
    [HideInInspector] public string[] eventPrompt;
    [HideInInspector] public int eventIndex;

    public void Update() 
    {
        if (canInteract) 
        {
            IinteractText.enabled = true;
            IinteractText.text = $"Press {interactKey} to {eventPrompt[eventIndex]}";
        }
        else IinteractText.enabled = false;
    }
}

