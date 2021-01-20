using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool isPaused;

    public List<Item> items = new List<Item>();
    public List<int> itemNumbers = new List<int>();
    public GameObject[] slots;

    public Item additem_01;

    //public Dictionary<Item, int> itemDict = new Dictionary<Item, int>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            if(instance != this)
            {
                Destroy(gameObject);
            }
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        Displayitem();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            AddItem(additem_01);
        }

    }

    private void Displayitem()
    {
        for(int i = 0; i < items.Count; i++)
        {
            slots[i].transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(0).GetComponent<Image>().sprite = items[i].itemsprite;

            slots[i].transform.GetChild(1).GetComponent<Text>().color = new Color(1, 1, 1, 1);
            slots[i].transform.GetChild(1).GetComponent<Text>().text = itemNumbers[i].ToString();

            slots[i].transform.GetChild(2).gameObject.SetActive(true);
            
        }
    }
    private void AddItem(Item _item)
    {
        if (!items.Contains(_item))
        {
            items.Add(_item);
            itemNumbers.Add(1);
        }
        else
        {
            Debug.Log("You alreadyahve thsi one");
            for(int i = 0; i < items.Count; i++)
            {
                if(_item == items[i])
                {
                    itemNumbers[i]++;
                }
            }
        }
        Displayitem();
    }
}
