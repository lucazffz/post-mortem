using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    #region Variables



    public static InventoryManager instance;
    public bool inventoryActivated;

    public List<Item> items = new List<Item>();
    public GameObject[] slots;

    public Item additem_01;

    #endregion

    private void Awake()
    {
        if(instance == null) instance = this;
        else if (instance != this) Destroy(gameObject);
       
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Displayitem();
    }

    private void Displayitem()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if(i < items.Count)
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemsprite;
            }
            else
            {
                slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 0);
                slots[i].transform.GetChild(0).GetComponent<Image>().sprite = null;
            }
        }
    }
    public void AddItem(Item _item)
    {
        if (!items.Contains(_item))
        {
            items.Add(_item);
        }
        else
        {
            Debug.Log("You already have this one");
        }
        Displayitem();
    }
    public void Removeitem(Item _item)
    {
        if (items.Contains(_item))
        {
            for(int i = 0; i < items.Count; i++)
            {
                if(_item == items[i]) items.Remove(_item);
            }
        }
        
        Displayitem();
    }

    public bool ContainsItem(Item _item)
    {
        if (items.Contains(_item)) return true;
        else return false;
    }
}



