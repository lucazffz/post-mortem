using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour
{
    public GameObject TransitionTo, Player;
   
   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            
        }
    }



    public void Transition()
    {
        Player.transform.position = TransitionTo.transform.position;
    }
}
