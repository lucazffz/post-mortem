using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupitem : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "Player")
        {
            
                Destroy(gameObject);
        }
    }
}
