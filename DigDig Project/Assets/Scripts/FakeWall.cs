using UnityEngine;

public class FakeWall : MonoBehaviour
{
    public Item map;

    private bool activated;

    private void Update()
    {
        if(!activated)
        {
            if (InventoryManager.instance.ContainsItem(map)) transform.GetChild(2).gameObject.SetActive(true);
            else transform.GetChild(2).gameObject.SetActive(false);
        }
    }

    public void RevealWall()
    {
        activated = true;

        if (InventoryManager.instance.ContainsItem(map))
        {
            for (int i = 0; i <= 2; i++) transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
