using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupitem : MonoBehaviour
{
    public Item itemData;

    public void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "Player")
        {
                Destroy(gameObject);

            GameManager.instance.AddItem(itemData);
        }
    }
}
