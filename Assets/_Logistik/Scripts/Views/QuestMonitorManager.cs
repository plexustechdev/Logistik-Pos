using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMonitorManager : MonoBehaviour
{
    [SerializeField] private CustomerCharacter _customer;
    [SerializeField] private QuestActiveView _questActiveView;
    [SerializeField] private GameObject _questListContainer, _questListTitle;
    [SerializeField] private CustomerCharacter _questCharacter;
    [SerializeField] private QuestController _questControl;

    private void OnEnable()
    {
        if (_questControl.activeQuest != null)
        {
            _customer.ShowActiveQuest();
            ShowActiveQuest();
        }
    }

    public void ShowActiveQuest()
    {
        _questActiveView.SetActiveQuest(_questControl.activeQuest.Description);

        _questListContainer.gameObject.SetActive(false);
        _questListTitle.gameObject.SetActive(false);
        _questActiveView.gameObject.SetActive(true);
    }

    public void HideActiveQuest()
    {
        _questListContainer.gameObject.SetActive(true);
        _questListTitle.gameObject.SetActive(true);
    }
}
