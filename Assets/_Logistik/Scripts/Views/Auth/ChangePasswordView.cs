using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class ChangePasswordView : MonoBehaviour
{
    [SerializeField] private TMP_InputField _oldPasswordTMP;
    [SerializeField] private TMP_InputField _newPasswordTMP;
    [SerializeField] private AuthNotifView _popUp;
    [SerializeField] private GameObject _objView, _loadingPanel;

    public void Btn_ChangePassword()
    {
        _loadingPanel.SetActive(true);

        string oldPassword = _oldPasswordTMP.text;
        string newPassword = _newPasswordTMP.text;
        
        if (newPassword.Any(Char.IsWhiteSpace) || oldPassword.Any(Char.IsWhiteSpace))
        {
            _popUp.SetWarning("Password baru memiliki spasi!");
            return;
        }

        if (oldPassword.Length < 6 || newPassword.Length < 6)
        {
            _popUp.SetWarning("Password minimal 6 karakter!");
            return;
        }

        FormUtils.SetFormChangePassword(oldPassword, newPassword);
        Authentication.instance.PostDataToken(Gateway.URI + Path.ChangePassword, FormUtils.GetForm, (result) =>
        {
            _loadingPanel.SetActive(false);

            ResponseChangePassword response = JsonConvert.DeserializeObject<ResponseChangePassword>(result);
            if (response.Status == "success")
            {
                _objView.SetActive(false);
                _popUp.SetWarning("Password berhasil diubah!");
            }
            else
            {
                _popUp.SetWarning("Password lama tidak sesuai!");
            }
        });
    }
}
