using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestLoad : MonoBehaviour
{
    [SerializeField] QuestMonitorManager _questMonitor;
    [SerializeField] DialogueView _dialogueView;

    private void Start()
    {
        if (QuestActiveController.ActiveQuest is null) return;

        if (QuestActiveController.isCompleteQuest) _questMonitor.CompleteQuest();

        if (QuestActiveController.ActiveQuest.IsFinished && QuestActiveController.ActiveQuest.Level == 10) _dialogueView.gameObject.SetActive(true);

        _questMonitor.FinishOrder();
    }
}
