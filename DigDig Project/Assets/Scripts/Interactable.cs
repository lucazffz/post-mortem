using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    //Variables

    private bool inRange;
    public KeyCode interactKey = KeyCode.E;
    public UnityEvent interactionEvent;

    public int eventIndex;

    void Update()
    {
        

        if (inRange)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().interactKey = interactKey;

            GameObject.Find("GameManager").GetComponent<GameManager>().eventIndex = eventIndex;

            if (Input.GetKeyDown(interactKey)) interactionEvent.Invoke();
            Debug.Log("Interaction");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) GameObject.Find("GameManager").GetComponent<GameManager>().activatePrompt = true;
        inRange = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) GameObject.Find("GameManager").GetComponent<GameManager>().activatePrompt = false;
        inRange = false;


    }

    
}

  
