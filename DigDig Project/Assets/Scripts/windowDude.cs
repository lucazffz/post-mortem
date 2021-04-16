using UnityEngine;

public class windowDude : MonoBehaviour
{
    public Item itemData;
    public GameObject interactableTrigger;

    private void Start()
    {
        interactableTrigger.SetActive(false);
    }
    private void Update()
    {
        if(InventoryManager.instance.ContainsItem(itemData))
        {
            interactableTrigger.SetActive(true);
            Destroy(this);
        }

    }
}
