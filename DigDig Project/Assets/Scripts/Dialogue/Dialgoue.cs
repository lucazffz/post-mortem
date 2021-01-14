using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialgoue
{
    public string name;
    public Sprite characterSprite;

    [TextArea(3, 6)]
    public string[] sentences;
}
