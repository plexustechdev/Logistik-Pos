using UnityEngine;

public static class FormUtils
{
    private static WWWForm _form;

    public static WWWForm GetForm => _form;

    public static void SetFormChangePassword(string oldPassword, string newPassword)
    {
        _form = new WWWForm();
        _form.AddField(FormField.OLD_PASSWORD, oldPassword);
        _form.AddField(FormField.NEW_PASSWORD, newPassword);
    }

    public static void SetFormLogin(string username, string password)
    {
        _form = new WWWForm();
        _form.AddField(FormField.USERNAME, username);
        _form.AddField(FormField.PASSWORD, password);
    }

    public static void SetFormRegister(string username, string phoneNumber, string email, string password)
    {
        _form = new WWWForm();
        _form.AddField(FormField.USERNAME, username);
        _form.AddField(FormField.PHONE_NUMBER, phoneNumber);
        _form.AddField(FormField.EMAIL, email);
        _form.AddField(FormField.PASSWORD, password);
    }

    public static void SetFormForgotPassword(string email)
    {
        _form = new WWWForm();
        _form.AddField(FormField.EMAIL, email);
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