using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    //Variables
    public bool inRange;

    public KeyCode interctKey = KeyCode.E;
    public UnityEvent interactionEvent;
    public GameObject promptText;

    private string[] eventType = {"open", "enter", "talk" };
    public int eventTypeIndex;

    private void Start() 
    {
        //if (transform.parent != null && transform.parent.tag == "npc") eventTypeIndex = 2;
        promptText.GetComponent<Text>().text = ($"Press {interctKey} to {eventType[eventTypeIndex]}");
    }
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(interctKey)) interactionEvent.Invoke();
            promptText.SetActive(true);
        }
       else promptText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) inRange = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")) inRange = false;
    }

}
  
