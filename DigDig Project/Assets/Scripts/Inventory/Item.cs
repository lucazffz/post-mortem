using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Item", fileName ="New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    [TextArea(3, 10)] public string itemDesc;


    public Sprite itemsprite;
}
