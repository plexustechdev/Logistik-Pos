using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Customer", menuName = "Customer/Level", order = 0)]
public class SO_Customer : ScriptableObject
{
    public string CustomerName;
    public Sprite SpriteCharacter, SpriteTable;
    public List<Quest> quests = new List<Quest>();
}

[Serializable]
public class Quest
{
    public int Level;
    public float GoodsAmount;
    [TextArea]
    public string Description;
    [TextArea]
    public string Narrative;
    public string Destination;
    public Transportation TransportationType;
    public float Timer;
    public bool IsActive;
    public bool IsFinished;
    public bool IsUsingTimer;
}


