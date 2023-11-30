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
    [SerializeField] private Button _acceptBtn;
    [SerializeField] private Button _denyBtn;

    [Header("Animation Properties")]
    [SerializeField] private Transform _startPos;
    [SerializeField] private Transform _endPos;

    public Button AcceptBtn => _acceptBtn;
    public Button DenyBtn => _denyBtn;

    public Image CharacterImage => _characterImage;
    public Image DialogueImage => _boxDialogueImg;

    public Transform StartAnimPos => _startPos;
    public Transform EndAnimPos => _endPos;

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

    public void AcceptOrder(Quest quest, QuestMonitorManager questView)
    {
        _acceptBtn.onClick.AddListener(() =>
        {
            quest.IsActive = true;
            // questController.SetActiveQuest(quest);
            QuestActiveController.SetActiveQuest(quest);
            questView.SetActiveQuest(quest.Description);
            questView.ShowActiveQuest();

            _boxDialogueImg.gameObject.SetActive(false);
            _acceptBtn.gameObject.SetActive(false);
            _denyBtn.gameObject.SetActive(true);
        });
    }

    public void CancelOrder(Quest quest, QuestMonitorManager questView)
    {
        _denyBtn.onClick.AddListener(() =>
        {
            quest.IsActive = false;
            // questController.SetActiveQuest(null);
            QuestActiveController.SetActiveQuest(quest);
            questView.HideActiveQuest();

            _boxDialogueImg.gameObject.SetActive(true);
            _denyBtn.gameObject.SetActive(false);
            _acceptBtn.gameObject.SetActive(true);

            gameObject.SetActive(false);
        });
    }
}
