using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Characters: ScriptableObject
{
    public new string name;
    public Sprite portrait;
}
