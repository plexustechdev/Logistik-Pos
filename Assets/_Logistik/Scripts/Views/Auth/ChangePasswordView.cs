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
        string oldPassword = _oldPasswordTMP.text;
        string newPassword = _newPasswordTMP.text;
        
        if (newPassword.Length < 6 || newPassword.Length < 6)
        {
            _popUp.SetWarning("Password minimal 6 karakter!");
            return;
        }

        if (newPassword.Any(Char.IsWhiteSpace) || newPassword.Any(Char.IsWhiteSpace))
        {
            _popUp.SetWarning("Password baru memiliki spasi!");
            return;
        }

        if (!IsPasswordValid(newPassword))
        {
            _popUp.SetWarning("<align=\"left\">Sepertinya kata sandi anda lemah, silakan pilih kata sandi yang kuat!\nKata sandi anda harus mengandung:\n<indent=2%>1. Satu huruf besar [AB],</indent>\n<indent=2%>2. Satu huruf kecil [ab],</indent>\n<indent=2%>3. Satu angka [123],</indent>\n<indent=2%>4. Satu karakter khusus [!@#].</indent>");
            return;
        }
        
        _loadingPanel.SetActive(true);
        
        FormUtils.SetFormChangePassword(oldPassword, newPassword);
        Authentication.instance.PostDataToken(Gateway.URI + Path.ChangePassword, FormUtils.GetForm, (result) =>
        {
            _loadingPanel.SetActive(false);

            var response = JsonConvert.DeserializeObject<ResponseChangePassword>(result);
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

    private bool IsPasswordValid(string password)
    {
        return password.Length >= 6 &&
               password.Any(char.IsDigit) &&
               password.Any(char.IsLetter) &&
               (password.Any(char.IsSymbol) || password.Any(char.IsPunctuation)) ;
    }
}
