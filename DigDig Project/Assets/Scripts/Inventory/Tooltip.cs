using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descText;

    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void Showtooltip()
    {   
        gameObject.SetActive(true);
    }
    public void Hidetooltip()
    {
        gameObject.SetActive(false);
    }
    public void Updatetooltip(string _nameText, string _descText)
    {
        nameText.text = _nameText;
        descText.text = _descText;
    }
}