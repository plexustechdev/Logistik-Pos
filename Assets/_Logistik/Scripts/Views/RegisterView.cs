using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RegisterView : MonoBehaviour
{
    [SerializeField] private UserController _regis;

    [Header("Property")]
    [SerializeField] private TMP_InputField _username;
    [SerializeField] private TMP_InputField _phoneNumber;
    [SerializeField] private TMP_InputField _email;
    [SerializeField] private TMP_InputField _password;

    public void Btn_Register(string path)
    {
        string username = _username.text;
        string phoneNumber = _phoneNumber.text;
        string email = _email.text;
        string password = _password.text;

        if (username != null && phoneNumber != null && email != null && password != null)
        {
            _regis.SetFormRegister(username, phoneNumber, email, password);
            _regis.SendData(path, (response) =>
            {
                print(response.Message);
            });
        }
    }
}
