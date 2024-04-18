using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Customer
{
    public string CustomerName;
    public Sprite SpriteCharacter, SpriteThumbnail;
    public List<Quest> quests;

    public Quest GetAvailableQuest()
    {
        return quests.FirstOrDefault();
    }
}
