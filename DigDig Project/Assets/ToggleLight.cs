using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleLight : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void LightMethod()
    {
        gameObject.SetActive(true);
    }
}