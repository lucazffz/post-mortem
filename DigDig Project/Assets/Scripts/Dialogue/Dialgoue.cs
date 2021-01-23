using UnityEngine;

[System.Serializable]
public class Dialgoue
{
    public Characters player, character;

    public Conversations[] conversations;

    [TextArea(1, 3)]
    public string[] fillerLines;
}

[System.Serializable]
public struct Conversations
{
    public bool playerStartTalking;
    public Sentences[] sentences;
}
[System.Serializable]
public struct Sentences
{
    [TextArea(1, 6)]
    public string[] lines;
}




