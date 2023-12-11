using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingView : MonoBehaviour
{
    private readonly float DEFAULT_POS_Y = -48;
    private readonly float OFFICE_POS_Y = -125;
    private RectTransform _rectObj;

    private void Awake()
    {
        _rectObj = GetComponent<RectTransform>();
    }

    public void DefaultPosView()
    {
        _rectObj.anchoredPosition = new Vector3(
            _rectObj.anchoredPosition.x,
            DEFAULT_POS_Y
        );
    }

    public void OfficePosView()
    {
        _rectObj.anchoredPosition = new Vector3(
            _rectObj.anchoredPosition.x,
            OFFICE_POS_Y
        );
    }
}
