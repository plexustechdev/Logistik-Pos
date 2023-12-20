using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class RegisterView : MonoBehaviour
{
    [Header("Property")]
    [SerializeField] private TMP_InputField _username;
    [SerializeField] private TMP_InputField _phoneNumber;
    [SerializeField] private TMP_InputField _email;
    [SerializeField] private TMP_InputField _password;

    [Header("Pop Up")]
    [SerializeField] private GameObject _loadingPanel;
    [SerializeField] private AuthNotifView _popUpAuth;
    [SerializeField] private GameObject _registrationPanel, _loginPanel;

    public void Btn_Register()
    {
        string username = _username.text;
        string phoneNumber = _phoneNumber.text;
        string email = _email.text;
        string password = _password.text;

        if (password.Length < 6)
        {
            _popUpAuth.SetWarning("Password minimal 6 karakter!");
            return;
        }
        
        if (username != string.Empty && phoneNumber != string.Empty && email != string.Empty && password != string.Empty)
        {
            _loadingPanel.SetActive(true);

            FormUtils.SetFormRegister(username, phoneNumber, email, password);
            Authentication.instance.PostData(Gateway.URI + Path.Register, FormUtils.GetForm, (result) =>
            {
                _loadingPanel.SetActive(false);

                ResponseRegister response = JsonConvert.DeserializeObject<ResponseRegister>(result);
                if (response.Status == "success")
                {
                    _popUpAuth.SetWarning("Silahkan cek email anda untuk verifikasi akun");
                    _registrationPanel.SetActive(false);
                    _loginPanel.SetActive(true);
                }
                else
                {
                    foreach (var message in response.Message)
                    {
                        if (message.Key == "email")
                            _popUpAuth.SetWarning("Email telah terdaftar!");
                        else if (message.Key == "phone_number")
                            _popUpAuth.SetWarning("Nomor telpon tidak valid!\nSilahkan masukkan nomor telepon\nminimal 10 digit");
                        else if (message.Key == "username")
                            _popUpAuth.SetWarning("Username telah terdaftar!");
                    }
                }
            });
        }
        else
        {
            _popUpAuth.SetWarning("Form tidak boleh kosong!");
        }
    }
}
