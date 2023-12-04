using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestActiveController
{
    public static Quest ActiveQuest { get; private set; }

    public static void SetActiveQuest(Quest quest = null)
    {
        ActiveQuest = quest;
    }
}