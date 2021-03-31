using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Text;

public class Itembutton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int buttonID;
    public Item thisItem;

    public Tooltip tooltip;
    private Vector2 position;

    private Item GetThisItem()
    {
        for (int i = 0; i < InventoryManager.instance.items.Count; i++)
        {
            if (buttonID == i)
            {
                thisItem = InventoryManager.instance.items[i];
            }
        }
        return thisItem;
    }
    public void CloseButton()
    {
        InventoryManager.instance.Removeitem(GetThisItem());
        thisItem = GetThisItem();
        if(thisItem != null)
        {

        }
        else
        {
        
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetThisItem();
        if (thisItem != null)
        {
            Debug.Log("Enter " + thisItem.itemName + " Slot");

            tooltip.Showtooltip();
            tooltip.Updatetooltip(thisItem.itemName, thisItem.itemDesc);


            RectTransformUtility.ScreenPointToLocalPointInRectangle(GameObject.Find("Inventory UI").transform as RectTransform, Input.mousePosition, null, out position);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(thisItem != null)
        {
        Debug.Log("Exit " + thisItem.itemName + " Slot");

            tooltip.Hidetooltip();
            tooltip.Updatetooltip("", "");
        }
    }

    /*
    private string Getdeatialtext(Item _item)
    {
        if(_item == null)
        {
            return "";
        }
        else
        {



            
            StringBuilder stringbuilder = new StringBuilder();
            stringbuilder.AppendFormat("Description {0}\n\n", _item.Desc);
            stringbuilder.AppendFormat("Item: {0}\n\n", _item.itemName);
            stringbuilder.AppendFormat("Description: {0}\n\n", _item.itemDesc);
            return stringbuilder.ToString();
            
        }
    }
    */
}
