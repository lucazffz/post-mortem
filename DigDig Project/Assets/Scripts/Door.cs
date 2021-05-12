using UnityEngine;

public class Door : MonoBehaviour
{
    public Item key;
    public bool locked;
    private bool canOpen;

    public bool isTrapdoor;

    public GameObject trigger;
   
    public void OpenDoor()
    {
        if (locked)
        {
            canOpen = false;

            if (InventoryManager.instance.items.Contains(key))
            {
                InventoryManager.instance.Removeitem(key);
                canOpen = true;
            }
            else
            {
                if(isTrapdoor)FindObjectOfType<PopupText>().ShowText("You don't have the required tool");
                else FindObjectOfType<PopupText>().ShowText("You don't have the required key");
            }
        }
        else canOpen = true;
       
        if(canOpen)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);

            GetComponent<Animator>().SetBool("open", true);
            FindObjectOfType<AudioManager>().PlaySound("DoorCreak");

            if (isTrapdoor) trigger.SetActive(true);

            if(isTrapdoor) FindObjectOfType<PopupText>().ShowText("Tool was removed from inventory");
            else FindObjectOfType<PopupText>().ShowText("Key was removed from inventory");
        }

        FindObjectOfType<AudioManager>().PlaySound("DoorHandle");
    }

   
        
    











}
