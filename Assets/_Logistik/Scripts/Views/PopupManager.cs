using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private PopupInfo popupInfo;

    [Space]
    [SerializeField] private string _title;
    [SerializeField] private string _description;

    public void GetInfo()
    {
        popupInfo.SetDetail(_title, _description);
        popupInfo.gameObject.SetActive(true);
    }
}
