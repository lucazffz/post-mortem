using UnityEngine;

public class Door : MonoBehaviour
{
    public Item key;
    public bool locked;
   
    private void Update()
    {
        
    }
    public void OpenDoor()
    {
        if(locked)
        {
            if (InventoryManager.instance.items.Contains(key))
            {
                InventoryManager.instance.Removeitem(key);

                GetComponent<BoxCollider2D>().enabled = false;
                transform.GetChild(0).gameObject.SetActive(false);

                GetComponent<Animator>().SetBool("open", true);
            }
            else
            {
                FindObjectOfType<PopupText>().ShowText("You don't have the requierd key");
            }
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
            GetComponent<Animator>().SetBool("open", true);
        }
        
    }

   
        
    











}
