using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMonitorManager : MonoBehaviour
{
    [SerializeField] private Customer _customer;
    [SerializeField] private QuestInfo _questInfo;
    [SerializeField] private GameObject _questContainer;

    private void Start()
    {

    }

    public void ShowActiveQuest(string title, string description, string amount, string destination)
    {
        _questInfo.SetActiveQuest(title, description, amount, destination);
        _questContainer.SetActive(false);
    }

    public void DisplayQuest()
    {
        _customer.gameObject.SetActive(true);
    }

    public void SetCustomerDialogueBox(string title, string description)
    {
        _customer.EnableDialogueBox(title, description);
    }

    public void ActivateQuest()
    {

    }
}
