using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEditor;


public class InteractableManager : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    [HideInInspector] public bool canInteract;
    [HideInInspector] public KeyCode interactKey;
    [HideInInspector] public string[] eventPrompt;
    [HideInInspector] public int eventIndex;



    public void Update()
    {
        if(canInteract == true)
        {
            textMeshPro.enabled = true;
            textMeshPro.text = $"Press {interactKey} to {eventPrompt[eventIndex]}";
        }
        else if(canInteract == false) textMeshPro.enabled = false;





    }
}

