using UnityEngine;
using System.Collections;

public class Pickupitem : MonoBehaviour
{
    public Item itemData;

    public Animator playerAnim;

    public void PickUp()
    {
        playerAnim.SetTrigger("PickUp");

        StartCoroutine(WaitTime());
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.3f);

        InventoryManager.instance.AddItem(itemData);
        FindObjectOfType<PopupText>().ShowText($"You pick up a {itemData.itemName}");
        Destroy(gameObject);


    }
}
