using UnityEngine;

[System.Serializable]
public class Dialgoue 
{
    public Characters interactCharacter;
    public Conversations[] conversations = new Conversations[1];

    [HideInInspector] public bool haveSpokenTo;
    [HideInInspector] public int sentenceIndex = 0, conversationIndex = 0;

    [Header("Filler Lines ---------------------------------------------------")]
    [Space] [TextArea(1, 3)] public string[] fillerLines;
}

[System.Serializable]
public struct Conversations 
{
    [Header("Conversation ---------------------------------------------------")]
    [Space] public SentenceGroups[] sentenceGroups;
}

[System.Serializable]
public struct SentenceGroups 
{
    [Space]  public Characters speaker;
    [TextArea(3, 6)] public string[] sentences;
}








