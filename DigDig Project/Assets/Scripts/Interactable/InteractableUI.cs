using UnityEngine;
using UnityEngine.UI;


public class InteractableUI : MonoBehaviour
{
    //Variables
    [HideInInspector] public bool activatePrompt;
    [HideInInspector] public KeyCode interactKey;
    
    [HideInInspector] public string[] eventPrompt = {"open", "enter", "unlock"};
    [HideInInspector] public int eventIndex;

    void Update()
    {
        //Set text elements
        GetComponent<Text>().text = ($"Press {interactKey} to {eventPrompt[eventIndex]}");

        //activate and deactivate text
        if (activatePrompt) GetComponent<Text>().enabled = true;
        else GetComponent<Text>().enabled = false;
    }
}
