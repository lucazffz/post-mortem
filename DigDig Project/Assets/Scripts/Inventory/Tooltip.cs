using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descText;

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
    public void Updatetooltip(string _nameText, string _descText)
    {
        nameText.text = _nameText;
        descText.text = _descText;
    }
}