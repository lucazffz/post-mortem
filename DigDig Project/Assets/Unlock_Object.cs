using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock_Object : MonoBehaviour
{
    GameManager gm;
    
    IEnumerable Start()
    {
          gm = GetComponent<GameManager>();
          yield return new WaitForEndOfFrame();
    }

    public void OpenObject()
    {
        foreach (Item local in gm.items)
        {
            
        }
    }

    void Update()
    {
        
    }
}
