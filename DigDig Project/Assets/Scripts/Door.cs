using UnityEngine;

public class Door : MonoBehaviour
{
    public Item key;
    public bool locked;
    private bool canOpen;
   
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
            else FindObjectOfType<PopupText>().ShowText("You don't have the requierd key");
        }
        else canOpen = true;
       
        if(canOpen)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);

            GetComponent<Animator>().SetBool("open", true);
            FindObjectOfType<AudioManager>().PlaySound("DoorCreak");
        }

        FindObjectOfType<AudioManager>().PlaySound("DoorHandle");
    }

   
        
    











}
