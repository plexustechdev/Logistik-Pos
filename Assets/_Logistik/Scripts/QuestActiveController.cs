using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestActiveController
{
    public static Quest ActiveQuest { get; private set; }

    public static bool isCompleteQuest = false;
    public static int currentLevel;

    public static void SetActiveQuest(Quest quest = null)
    {
        ActiveQuest = quest;
    }

    public static void ShowDialogueEnd()
    {
        DialogueView.instance.ShowLastDialogue();
    }
}