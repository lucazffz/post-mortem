using UnityEngine;

[System.Serializable]
public class Dialgoue
{
    [TextArea(3, 6)]
    public string[] sentences;

    public string fullName;
    public Sprite characterSprite;

    public bool playerStartTalking;

    [TextArea(1, 3)]
    public string[] randomSentences;
}
