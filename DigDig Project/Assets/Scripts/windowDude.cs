using UnityEngine;

public class windowDude : MonoBehaviour
{
    public Item itemData;
    public GameObject interactableTrigger;

    private void Start()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
    private void Update()
    {
        if(InventoryManager.instance.ContainsItem(itemData))
        {
            Destroy(interactableTrigger);
            transform.GetChild(0).gameObject.SetActive(true);

        }
        
    }
}
