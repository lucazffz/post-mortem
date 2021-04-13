using UnityEngine;

public class Pickupitem : MonoBehaviour
{
    public Item itemData;

    public void PickUp()
    {
        Destroy(gameObject);
        InventoryManager.instance.AddItem(itemData);
        FindObjectOfType<PopupText>().ShowText($"You pick up a {itemData.itemName}");
    }
}
