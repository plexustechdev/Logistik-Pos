using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestActiveView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _descriptionTmp;

    public void SetActiveQuest(string description)
    {
        _descriptionTmp.text = description;
    }
}
