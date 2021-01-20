using UnityEngine;

[System.Serializable]
public class Dialgoue
{
    public string name;
    public Sprite characterSprite;

    public bool playerStartTalking;

    [TextArea(3, 6)]
    public string[] sentences;

    [TextArea(1, 3)]
    public string[] randomSentences;
}
