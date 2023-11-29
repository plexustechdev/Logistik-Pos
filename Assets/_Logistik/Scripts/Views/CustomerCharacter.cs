using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class CustomerCharacter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _descriptionTMP;
    [SerializeField] private TextMeshProUGUI _narrativeTmp;
    [Space]
    [SerializeField] private Image _characterImage;
    [SerializeField] private Image _boxDialogueImg;
    [Space]
    public Button AcceptBtn;
    public Button DenyBtn;

    public void ShowQuest(string description, string narrative, Sprite characterSprite)
    {
        _descriptionTMP.text = description;
        _narrativeTmp.text = narrative;
        _characterImage.sprite = characterSprite;
        _boxDialogueImg.gameObject.SetActive(true);
    }

    public void QuestActiveView()
    {
        _boxDialogueImg.gameObject.SetActive(false);
        gameObject.SetActive(true);
    }


    public void AcceptOrder(Quest quest, QuestActiveController questController, QuestMonitorManager questView)
    {
        AcceptBtn.onClick.AddListener(() =>
        {
            quest.IsActive = true;
            questController.SetActiveQuest(quest);
            questView.SetActiveQuest(quest.Description);
            questView.ShowActiveQuest();

            _boxDialogueImg.gameObject.SetActive(false);
            AcceptBtn.gameObject.SetActive(false);
            DenyBtn.gameObject.SetActive(true);
        });
    }

    public void CancelOrder(Quest quest, QuestActiveController questController, QuestMonitorManager questView)
    {
        DenyBtn.onClick.AddListener(() =>
        {
            quest.IsActive = false;
            questController.SetActiveQuest(null);
            questView.HideActiveQuest();

            _boxDialogueImg.gameObject.SetActive(true);
            DenyBtn.gameObject.SetActive(false);
            AcceptBtn.gameObject.SetActive(true);

            gameObject.SetActive(false);
        });
    }
}
