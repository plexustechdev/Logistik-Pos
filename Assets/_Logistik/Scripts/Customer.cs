using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Customer
{
    public string CustomerName;
    public Sprite SpriteCharacter, SpriteThumbnail;
    public List<Quest> quests;

    public Quest GetAvailableQuest()
    {
        for (int i = 0; i < quests.Count; i++)
        {
            if (!quests[i].IsFinished)
                return quests[i];
        }

        return null;
    }
}
