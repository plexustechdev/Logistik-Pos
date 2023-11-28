using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    [SerializeField] public Quest activeQuest { get; private set; }

    public void SetActiveQuest(Quest quest)
    {
        if (quest is null) return;

        activeQuest = quest;
    }
}
