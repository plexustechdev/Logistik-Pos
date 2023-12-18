using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CustomerQuestView : MonoBehaviour
{
    [SerializeField] private Image _customerImage, _lockedImage;
    [SerializeField] private TextMeshProUGUI _customerNameTmp;
    [SerializeField] private Button _questBtn;

    public Button QuestBtn => _questBtn;

    public void SetCustomer(Sprite customerImage, string customerName, bool isLocked)
    {
        _customerImage.sprite = customerImage;
        _customerNameTmp.text = customerName;
        CheckIsLocked(isLocked);
    }

    public void SetCustomer(Sprite customerImage, string customerName)
    {
        _customerImage.sprite = customerImage;
        _customerNameTmp.text = customerName;
    }

    private void CheckIsLocked(bool isLocked)
    {
        if (isLocked)
        {
            _lockedImage.gameObject.SetActive(true);
            _questBtn.interactable = false;
        }
        else
        {
            _lockedImage.gameObject.SetActive(false);
            _questBtn.interactable = true;
        }
    }
}
