using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AuthNotifView : MonoBehaviour
{
    [SerializeField] private GameObject _panelPopUp;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private TextMeshProUGUI _warningTMP;

    public void SetWarning(string warning)
    {
        _warningTMP.text = warning;
        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
        LayoutRebuilder.ForceRebuildLayoutImmediate(rectTransform);
        _panelPopUp.SetActive(true);
    }
}
