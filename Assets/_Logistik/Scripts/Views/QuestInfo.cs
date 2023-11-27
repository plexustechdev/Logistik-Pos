using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleTmp;
    [SerializeField] private TextMeshProUGUI _descriptionTmp;
    [SerializeField] private TextMeshProUGUI _amountTmp;
    [SerializeField] private TextMeshProUGUI _destinationTmp;

    public void SetActiveQuest(string title, string description, string amount, string destination)
    {
        _titleTmp.text = title;
        _descriptionTmp.text = description;
        _amountTmp.text = amount;
        _descriptionTmp.text = destination;
    }
}
