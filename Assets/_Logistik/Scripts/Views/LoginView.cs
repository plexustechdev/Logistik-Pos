using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoginView : MonoBehaviour
{
    [SerializeField] private UserController _login;

    [Header("Property")]
    [SerializeField] private TMP_InputField _username;
    [SerializeField] private TMP_InputField _password;

    public void Btn_Login(string path)
    {
        string username = _username.text;
        string password = _password.text;

        if (username != null && password != null)
        {
            _login.SetFormLogin(username, password);
            _login.SendData(path, (response) =>
            {
                print(response.GetUser.Token);
            });
        }
    }
}
