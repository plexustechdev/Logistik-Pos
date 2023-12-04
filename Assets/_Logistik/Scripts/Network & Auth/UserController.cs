using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class UserController : MonoBehaviour
{
    [SerializeField] private Authentication _authentication;

    private WWWForm _form;

    public void SetFormRequestCode(string email)
    {
        _form = new WWWForm();
        _form.AddField(FormField.EMAIL, email);
    }

    public void SetFormResetPassword(string code, string newPassword)
    {
        _form = new WWWForm();
        _form.AddField(FormField.CODE, code);
        _form.AddField(FormField.NEW_PASSWORD, newPassword);
    }

    public void SetFormResetPasswordProfile(string oldPassword, string newPassword)
    {
        _form = new WWWForm();
        _form.AddField(FormField.OLD_PASSWORD, oldPassword);
        _form.AddField(FormField.NEW_PASSWORD, newPassword);
    }

    public void SetFormLogin(string username, string password)
    {
        _form = new WWWForm();
        _form.AddField(FormField.USERNAME, username);
        _form.AddField(FormField.PASSWORD, password);
    }

    public void SetFormRegister(string username, string phoneNumber, string email, string password)
    {
        _form = new WWWForm();
        _form.AddField(FormField.USERNAME, username);
        _form.AddField(FormField.PHONE_NUMBER, phoneNumber);
        _form.AddField(FormField.EMAIL, email);
        _form.AddField(FormField.PASSWORD, password);
    }

    public void SetFormVerifyEmail(string code)
    {
        _form = new WWWForm();
        _form.AddField(FormField.CODE, code);
    }

    public void SendData(string path, Action<Response> callback)
    {
        _authentication.PostData(Gateway.URI + path, _form);
        var response = _authentication.GetResponse;
        callback(response);
    }
}

public static class FormField
{
    public static string USERNAME = "username";
    public static string PASSWORD = "password";
    public static string OLD_PASSWORD = "old_password";
    public static string NEW_PASSWORD = "new_password";
    public static string PHONE_NUMBER = "phone_number";
    public static string EMAIL = "email";
    public static string CODE = "code";
}

public static class Gateway
{
    public static string URI = "https://doddi.plexustechdev.com/logistic-quest/laravel/public/api/";
}