using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PasswordView : MonoBehaviour
{
    [SerializeField] private TMP_InputField _passwordInputField;
    [SerializeField] private Image _eyeIcon;

    [Header("Sprite Icon")]
    [SerializeField] private Sprite showSprite;
    [SerializeField] private Sprite hideSprite;

    public void TogglePassword()
    {
        if (_passwordInputField.contentType == TMP_InputField.ContentType.Password) ShowPassword();
        else HidePassword();

        _passwordInputField.ForceLabelUpdate();
    }

    private void ShowPassword()
    {
        _passwordInputField.contentType = TMP_InputField.ContentType.Standard;
        _eyeIcon.sprite = hideSprite;
    }

    private void HidePassword()
    {
        _passwordInputField.contentType = TMP_InputField.ContentType.Password;
        _eyeIcon.sprite = showSprite;
    }
}
