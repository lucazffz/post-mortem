using UnityEngine;

[System.Serializable]
public class Dialgoue
{
    public string name;
    public Sprite characterSprite;

    [TextArea(3, 6)]
    public string[] storySentences;

    [TextArea(1, 3)]
    public string[] randomSentences;
}
