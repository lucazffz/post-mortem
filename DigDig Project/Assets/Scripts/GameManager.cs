using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    #region Variables

    //Variables

    //interactable
    [HideInInspector] public bool activatePrompt;
    [HideInInspector] public KeyCode interactKey;
    public GameObject promptText;

    public string[] eventPrompt = {"open", "enter", "unlock"};
    public int eventIndex;

    #endregion

    void Update()
    {
        //interactable
        
        if (activatePrompt)
        {
            promptText.GetComponent<Text>().text = ($"Press {interactKey} to {eventPrompt[eventIndex]}");

            promptText.SetActive(true);
        }
        else promptText.SetActive(false);


    }
}
