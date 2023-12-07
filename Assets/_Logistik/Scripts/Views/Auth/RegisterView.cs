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
    [SerializeField] private AuthNotifView _popUpAuth;
    [SerializeField] private GameObject _registrationPanel, _loginPanel;

    public void Btn_Register()
    {
        string username = _username.text;
        string phoneNumber = _phoneNumber.text;
        string email = _email.text;
        string password = _password.text;

        if (username != string.Empty && phoneNumber != string.Empty && email != string.Empty && password != string.Empty)
        {
            FormUtils.SetFormRegister(username, phoneNumber, email, password);
            Authentication.instance.PostData(Gateway.URI + Path.Register, FormUtils.GetForm, (result) =>
            {
                ResponseRegister response = JsonConvert.DeserializeObject<ResponseRegister>(result);
                print(response.Status);
                print(response.Error_code);
                if (response.Status == "success")
                {
                    _popUpAuth.SetWarning("Silahkan cek email anda untuk verifikasi akun");
                    _registrationPanel.SetActive(false);
                    _loginPanel.SetActive(true);
                }
                else
                {
                    _popUpAuth.SetWarning("Akun telah terdaftar!");
                }
            });
        }
        else
        {
            _popUpAuth.SetWarning("Form tidak boleh kosong!");
        }
    }
}
