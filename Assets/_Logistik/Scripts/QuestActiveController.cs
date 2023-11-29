using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestActiveController : MonoBehaviour
{
    public Quest ActiveQuest { get; private set; }

    public void SetActiveQuest(Quest quest)
    {
        if (ActiveQuest != null) return;

        ActiveQuest = quest;
    }
}