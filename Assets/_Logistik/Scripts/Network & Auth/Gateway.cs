using System;

public static class Gateway
{
    private static string uri = "https://loquestic.posindonesia.co.id/laravel/public/api/";

    public static string URI => uri;
    public static string SetUri(string newUri) => uri = newUri;
}

public static class Path
{
    #region User Auth
    public static string Login = "playersLogin";
    public static string Register = "players";
    public static string GetProfile = "getprofile";
    public static string Logout = "logout";

    public static string ForgotPassword = "password/email";
    public static string ChangePassword = "reset-first-password";
    #endregion

    #region User Wallet
    public static string Wallets = "wallets";
    #endregion

    #region User
    public static string Leaderboard = "leaderboards?page=1";
    #endregion
}
