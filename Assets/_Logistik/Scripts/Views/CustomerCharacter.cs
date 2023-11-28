using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CustomerCharacter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleTmp;
    [SerializeField] private TextMeshProUGUI _descriptionTmp;
    [SerializeField] private Image _boxDialogueImg;
    public Button AcceptBtn;
    public Button DenyBtn;

    public void ShowQuest(string title, string description)
    {
        _titleTmp.text = title;
        _descriptionTmp.text = description;
        _boxDialogueImg.gameObject.SetActive(true);
    }

    public void ShowActiveQuest()
    {
        _boxDialogueImg.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }


    public void AcceptOrder(Quest quest, QuestController questController, QuestMonitorManager questView)
    {
        AcceptBtn.onClick.AddListener(() =>
        {
            quest.IsActive = true;
            questController.SetActiveQuest(quest);
            questView.ShowActiveQuest();
            DenyBtn.gameObject.SetActive(true);
        });
    }

    public void CancelOrder(QuestController quest)
    {
        quest.SetActiveQuest(null);
        DenyBtn.gameObject.SetActive(false);
        AcceptBtn.gameObject.SetActive(true);
    }
}
