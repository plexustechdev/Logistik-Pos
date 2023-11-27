using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerQuest : MonoBehaviour
{
    [SerializeField] private SO_QuestLevel _questLevel;
    [SerializeField] private QuestMonitorManager _questMonitor;

    public void ShowQuest()
    {
        string quest = $"Quest {_questLevel.Level.ToString()}";
        string description = _questLevel.Description;
        string goodsAmount = _questLevel.GoodsAmount.ToString();
        string destination = _questLevel.Destination;

        _questMonitor.DisplayQuest();
        _questMonitor.SetCustomerDialogueBox(quest, description);
    }

    public void ActivateQuest()
    {

    }
}
