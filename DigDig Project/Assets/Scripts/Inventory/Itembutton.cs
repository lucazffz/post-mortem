using UnityEngine;
using UnityEngine.EventSystems;

public class Itembutton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int buttonID;
    public Item thisItem;

    public Tooltip tooltip;
   
    private Item GetThisItem()
    {
        for (int i = 0; i < InventoryManager.instance.items.Count; i++)
        {
            if (buttonID == i) thisItem = InventoryManager.instance.items[i];
        }
        return thisItem;
    }
   
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetThisItem();
        if (thisItem != null)
        {
            tooltip.Showtooltip();
            tooltip.Updatetooltip(thisItem.itemName, thisItem.itemDesc);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(thisItem != null)
        {
            tooltip.Hidetooltip();
            thisItem = null;
        }
    }
}
