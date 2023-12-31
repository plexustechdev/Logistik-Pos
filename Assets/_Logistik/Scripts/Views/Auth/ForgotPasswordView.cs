using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class ForgotPasswordView : MonoBehaviour
{
    [SerializeField] private GameObject _forgotPasswordObj;

    [SerializeField] private TMP_InputField _emailTMP;
    [SerializeField] private AuthNotifView _popUp;
    [SerializeField] private GameObject _loadingPanel;

    public void Btn_ForgotPassword()
    {
        _loadingPanel.SetActive(true);

        string email = _emailTMP.text;

        FormUtils.SetFormForgotPassword(email);
        Authentication.instance.PostData(Gateway.URI + Path.ForgotPassword, FormUtils.GetForm, (result) =>
        {
            _loadingPanel.SetActive(false);

            ResponseForgotPassword response = JsonConvert.DeserializeObject<ResponseForgotPassword>(result);
            if (response.Status == "success")
            {
                _forgotPasswordObj.SetActive(false);
                _popUp.SetWarning("Silahkan cek email anda!");
            }
            else
            {
                _forgotPasswordObj.SetActive(false);
                _popUp.SetWarning("Email tidak ditemukan!");
                print(response.Error_code);
            }
        });
    }
}
