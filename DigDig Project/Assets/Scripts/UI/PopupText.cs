using TMPro;
using UnityEngine;
using System.Collections;

public class PopupText : MonoBehaviour
{
    public TextMeshProUGUI Itext;

    public void Start()
    {
        Itext.enabled = false;
    }
    public void ShowText(string text)
    {
        Itext.text = text;

        StartCoroutine(FadeTextToFullAlpha(1f, Itext));
    }

    public IEnumerator FadeTextToFullAlpha(float t, TextMeshProUGUI i)
    {
        Itext.enabled = true;

        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while (i.color.a < 1.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
            yield return null;
        }

        StartCoroutine(FadeTextToZeroAlpha(1f, Itext));
    }

    public IEnumerator FadeTextToZeroAlpha(float t, TextMeshProUGUI i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }

        Itext.enabled = false;
    }
}


