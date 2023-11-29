using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMonitorManager : MonoBehaviour
{
    [SerializeField] private CustomerCharacter _customer;
    [SerializeField] private QuestActiveView _questActiveView;
    [SerializeField] private GameObject _questListContainer, _questListTitle;
    [SerializeField] private CustomerCharacter _questCharacter;
    [SerializeField] private QuestActiveController _questControl;

    private void OnEnable()
    {
        if (_questControl.ActiveQuest is null) return;

        _customer.ShowActiveQuest();
        ShowActiveQuest();
    }

    public void ShowActiveQuest()
    {
        _questActiveView.SetActiveQuest(_questControl.ActiveQuest.Description);

        _questListContainer.gameObject.SetActive(false);
        _questListTitle.gameObject.SetActive(false);
        _questActiveView.gameObject.SetActive(true);
    }

    public void HideActiveQuest()
    {
        _questListContainer.gameObject.SetActive(true);
        _questListTitle.gameObject.SetActive(true);
        _questActiveView.gameObject.SetActive(false);
    }
}
