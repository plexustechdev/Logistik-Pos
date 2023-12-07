using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : MonoBehaviour
{
    [Header("Property")]
    [SerializeField] private TMP_InputField _username;
    [SerializeField] private TMP_InputField _password;

    [Header("Pop Up")]
    [SerializeField] private AuthNotifView _popUpAuth;
    [SerializeField] private Canvas _overworldCanvas, _loginCanvas;
    [SerializeField] private DialogueView _dialogue;

    public void Btn_Login()
    {
        string username = _username.text;
        string password = _password.text;

        if (username != string.Empty && password != string.Empty)
        {
            FormUtils.SetFormLogin(username, password);
            Authentication.instance.PostData(Gateway.URI + Path.Login, FormUtils.GetForm, (result) =>
            {
                ResponseLogin response = JsonConvert.DeserializeObject<ResponseLogin>(result);
                if (response.Status == "success")
                {
                    AuthenticationSession.CacheToken(response.Data.Token);
                    _overworldCanvas.gameObject.SetActive(true);
                    _loginCanvas.gameObject.SetActive(false);
                    _dialogue.gameObject.SetActive(true);
                }
                else
                {
                    if (response.Error_code == ErrorCode.NOT_VERIFIED.ToString())
                        _popUpAuth.SetWarning("AKUN BELUM TERVERIFIKASI!\nSilahkan cek email anda secara berkala, untuk memverifikasi akun anda!");
                    else
                        _popUpAuth.SetWarning("AKUN BELUM TERDAFTAR!\nSilahkan untuk mendaftarkan akun anda!");
                }
            });
        }
        else
        {
            _popUpAuth.SetWarning("Username dan password\ntidak boleh kosong!");
        }
    }
}
