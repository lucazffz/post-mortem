using UnityEngine;

public class Door : MonoBehaviour
{
    public Item key;
    public bool needKey;

    public void OpenDoor()
    {
        GetComponent<Animator>().SetBool("open", true);

        if(needKey)
        {
            if (InventoryManager.instance.items.Contains(key))
            {
                InventoryManager.instance.Removeitem(key);

                GetComponent<BoxCollider2D>().enabled = false;
                transform.GetChild(0).gameObject.SetActive(false);
            }
        }
        else
        {
            GetComponent<BoxCollider2D>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
        }
        
    }

   
        
    











}
