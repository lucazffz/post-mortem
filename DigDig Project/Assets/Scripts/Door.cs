using UnityEngine;

public class Door : MonoBehaviour
{
    public Item key;

    public void OpenDoor()
    {
        if (InventoryManager.instance.items.Contains(key))
        {
            InventoryManager.instance.Removeitem(key);

            GetComponent<BoxCollider2D>().enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }

   
        
    











}
