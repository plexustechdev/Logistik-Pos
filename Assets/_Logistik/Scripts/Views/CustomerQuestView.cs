using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomerQuestView : MonoBehaviour
{
    [SerializeField] private Image _customerImage;
    [SerializeField] private TextMeshProUGUI _customerNameTmp;
    [SerializeField] private Button _questBtn;

    public Button QuestBtn => _questBtn;

    public void SetCustomer(Sprite customerImage, string customerName)
    {
        _customerImage.sprite = customerImage;
        _customerNameTmp.text = customerName;
    }
}
