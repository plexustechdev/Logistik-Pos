using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestMonitorManager : MonoBehaviour
{
    public Quest availableQuest;
    [SerializeField] private CustomerCharacter _customer;
    [SerializeField] private QuestActiveView _questActiveView;
    [SerializeField] private GameObject _questListContainer, _questListTitle;
    // [SerializeField] private CustomerCharacter _questCharacter;

    [SerializeField] private Button _acceptBtn;
    [SerializeField] private Button _denyBtn;
    
    // public Button AcceptBtn => _acceptBtn;
    // public Button DenyBtn => _denyBtn;
    // [SerializeField] private QuestActiveController _questControl;

    [SerializeField] private CustomerController customerController;
    [SerializeField] private CustomerCharacter customerCharacter;

    private void Start()
    {
        if (QuestActiveController.ActiveQuest is null) return;
        ShowAvailableQuest();
    }

    private void ShowAvailableQuest()
    {
        _customer.QuestActiveView();
        SetActiveQuest(QuestActiveController.ActiveQuest.Description);
        customerController.selectedCustomer = GameManager.instance.dataCustomer.Customers[QuestActiveController.ActiveQuest.Level - 1];
        _customer.GetComponent<Image>().sprite = customerController.selectedCustomer.SpriteCharacter;
        ShowAcceptButton(false);
        _customer.GetComponent<Image>().color = Color.white;
        ShowActiveQuest();
    }

    public void ShowActiveQuest()
    {
        _questListContainer.gameObject.SetActive(false);
        _questListTitle.gameObject.SetActive(false);
        _questActiveView.gameObject.SetActive(true);
    }

    public void SetActiveQuest(string description)
    {
        _questActiveView.SetActiveQuest(description);
    }

    public void HideActiveQuest()
    {
        _questListContainer.gameObject.SetActive(true);
        _questListTitle.gameObject.SetActive(true);
        _questActiveView.gameObject.SetActive(false);
    }

    public void ShowAcceptButton(bool val)
    {
        _acceptBtn.gameObject.SetActive(val);
        _denyBtn.gameObject.SetActive(!val);
    }

    public void ShowBtns(bool val)
    {
        _acceptBtn.gameObject.SetActive(val);
        _denyBtn.gameObject.SetActive(val);
    }

    public void AcceptOrder()
    {
        if (customerController.selectedCustomer == null) return;
        availableQuest.IsActive = true;
        QuestActiveController.SetActiveQuest(availableQuest);
        SetActiveQuest(availableQuest.Description);
        ShowActiveQuest();
        
        customerCharacter.DialogueImage.gameObject.SetActive(false);
        _acceptBtn.gameObject.SetActive(false);
        _denyBtn.gameObject.SetActive(true);
        GuideView.instance.GuideOffice();
    }

    public void CancelOrder()
    {
        availableQuest.IsActive = false;
        QuestActiveController.isCompleteQuest = false;
        QuestActiveController.SetActiveQuest();
        customerController.selectedCustomer = null;

        HideActiveQuest();

        customerCharacter.DialogueImage.gameObject.SetActive(true);
        ShowBtns(false);
        customerController.tweening.HideCustomer(_customer.CharacterImage, _customer.DialogueImage);

        GuideView.instance.DeactivateGuide();
    }

    public void FinishOrder()
    {
        QuestActiveController.SetActiveQuest();
        customerController.selectedCustomer = null;

        HideActiveQuest();

        customerCharacter.DialogueImage.gameObject.SetActive(true);
        ShowBtns(false);
        customerController.tweening.HideCustomer(_customer.CharacterImage, _customer.DialogueImage);

        GuideView.instance.DeactivateGuide();
    }

    public void CompleteQuest()
    {
        QuestActiveController.ActiveQuest.IsFinished = true;
        QuestActiveController.ActiveQuest.IsActive = false;

        QuestActiveController.isCompleteQuest = false;
    }
}
