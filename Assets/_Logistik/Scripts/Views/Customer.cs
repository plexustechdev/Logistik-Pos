using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using JetBrains.Annotations;

public class Customer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _titleTmp;
    [SerializeField] private TextMeshProUGUI _descriptionTmp;
    [SerializeField] private Image _boxDialogueImg;
    public Button AcceptBtn;
    public Button DenyBtn;

    public void EnableDialogueBox(string title, string description)
    {
        _titleTmp.text = title;
        _descriptionTmp.text = description;
        _boxDialogueImg.gameObject.SetActive(true);
    }

    public void AcceptQuest()
    {
        _boxDialogueImg.gameObject.SetActive(false);
        AcceptBtn.gameObject.SetActive(false);
        DenyBtn.gameObject.SetActive(true);
    }
}
