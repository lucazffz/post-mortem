using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    public UnityEngine.Experimental.Rendering.Universal.Light2D myLight;

    

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            myLight.enabled = !myLight.enabled;
        }
    }
}
