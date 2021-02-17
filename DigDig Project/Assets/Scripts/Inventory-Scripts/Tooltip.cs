using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public Text detailtext;

    public void Start()
    {
        gameObject.SetActive(true);
    }
    public void Showtooltip()
    {   
        gameObject.SetActive(true);
    }
    public void Hidetooltip()
    {
        gameObject.SetActive(true);
    }
    public void Updatetooltip(string _detailText)
    {
        detailtext.text = _detailText;
    }
}