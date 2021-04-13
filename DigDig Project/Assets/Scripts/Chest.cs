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
        if(locked)
        {
            if (InventoryManager.instance.items.Contains(key))
            {
                canOpen = true;
                InventoryManager.instance.Removeitem(key);
            }
            else
            {
                canOpen = false;
                FindObjectOfType<PopupText>().ShowText("You don't have the requierd key");

                FindObjectOfType<AudioManager>().PlaySound("ChestLocked");
            }
        }

        if (canOpen)
        {
            GetComponent<Animator>().SetBool("open", true);

            foreach (var item in items) InventoryManager.instance.AddItem(item);
            transform.GetChild(0).gameObject.SetActive(false);

            if(items.Count > 1) FindObjectOfType<PopupText>().ShowText($"You picked up {items.Count} items");
            else FindObjectOfType<PopupText>().ShowText($"You picked up 1 item");

            FindObjectOfType<AudioManager>().PlaySound("ChestOpen");

        }
    }
}
