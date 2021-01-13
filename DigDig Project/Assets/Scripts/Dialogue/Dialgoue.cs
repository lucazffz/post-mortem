using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialgoue
{
    public string name;

    [TextArea(3, 6)]
    public string[] sentences;
}
