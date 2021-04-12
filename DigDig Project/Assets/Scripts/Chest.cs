using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    public bool locked;
    public Item key;
    private bool canOpen = true;

   public void OpenChest()
    {
        GetComponent<Animator>().SetBool("open", true);

        if(locked)
        {
            if (InventoryManager.instance.items.Contains(key))
            {
                canOpen = true;
                InventoryManager.instance.Removeitem(key);
            }
            else canOpen = false;
        }

        if (canOpen)
        {
            foreach (var item in items) InventoryManager.instance.AddItem(item);
            transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
