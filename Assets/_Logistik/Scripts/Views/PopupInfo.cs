using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleTMP;
    [SerializeField] private TextMeshProUGUI _descriptionTMP;

    public void SetDetail(string title, string description)
    {
        _titleTMP.text = title;
        _descriptionTMP.text = description;
    }
}
