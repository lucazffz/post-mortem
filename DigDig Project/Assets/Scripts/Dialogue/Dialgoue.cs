using UnityEngine;

[System.Serializable]
public class Dialgoue
{
    public Characters interactCharacter;

    public Conversations[] conversations;

    [HideInInspector]
    public bool haveSpokenTo;
    [HideInInspector]
    public int sentenceIndex = 0, conversationIndex = 0;

    [TextArea(1, 3)]
    public string[] fillerLines;
}

[System.Serializable]
public struct Conversations
{
    public SentenceGroups[] sentenceGroups;
}
[System.Serializable]
public struct SentenceGroups
{
    public Characters speaker;

    [TextArea(1, 6)]
    public string[] sentences;
}




