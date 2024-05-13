using System;
using System.Collections.Generic;

public interface IResponse
{
    string Status { get; set; }
    string Message { get; set; }
}

[Serializable]
public class ResponseLogin : IResponse
{
    public string Status { get; set; }
    public string Message { get; set; }
    public DataLogin Data { get; set; }
    public string Error_code { get; set; }
}

[Serializable]
public class DataLogin
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }
}

[Serializable]
public class ResponseRegister
{
    public string Status { get; set; }
    public List<Message> Message { get; set; }
    public DataRegister Data { get; set; }
    public string Error_code { get; set; }
}

public class Message
{
    public string Key { get; set; }
    public string Value { get; set; }
}

[Serializable]
public class DataRegister
{
    public string Email { get; set; }
    public string Phone_number { get; set; }
    public string Username { get; set; }
    public string Updated_at { get; set; }
    public string Created_at { get; set; }
    public int Id { get; set; }
}

[Serializable]
public class ResponseProfile : IResponse
{
    public string Status { get; set; }
    public string Message { get; set; }
    public DataProfile Data { get; set; }
}

[Serializable]
public class DataProfile
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Phone_number { get; set; }
}

[Serializable]
public class ResponseLeaderboard : IResponse
{
    public string Status { get; set; }
    public LeaderboardPeringkat Peringkat { get; set; }
    public int CurrentPage { get; set; }
    public int LastPage { get; set; }
    public int NextPage { get; set; }
    public int PrevPage { get; set; }
    public int PerPage { get; set; }
    public int Total { get; set; }
    public List<LeaderboardData> Data { get; set; }
    public string Message { get; set; }
}

public class LeaderboardPeringkat
{
    public string Username { get; set; }
    public int Player_Id { get; set; }
    public float Total_amount { get; set; }
    public int Rank { get; set; }
}

public class LeaderboardData
{
    public string Username { get; set; }
    public int Player_Id { get; set; }
    public float Total_amount { get; set; }
    public int Rank { get; set; }
}

[Serializable]
public class ResponseWallet : IResponse
{
    public string Status { get; set; }
    public string Message { get; set; }
    public string Total_wallet { get; set; }
}

[Serializable]
public class ResponseWalletSend
{
    public string Status { get; set; }
    public List<WalletData> Message { get; set; }
    public string Error_Code { get; set; }
}

[Serializable]
public class WalletData
{
    public string Key { get; set; }
    public string Value { get; set; }
}

[Serializable]
public class ResponseLogout : IResponse
{
    public string Status { get; set; }
    public string Message { get; set; }
}

[Serializable]
public class ResponseForgotPassword
{
    public string Status { get; set; }
    // public string Message { get; set; }
    public string Error_code { get; set; }
}

[Serializable]
public class ResponseChangePassword : IResponse
{
    public string Status { get; set; }
    public string Key { get; set; }
    public string Message { get; set; }
}

[Serializable]
public class ResponsePlay : IResponse
{
    public string Status { get; set; }
    public string Message { get; set; }
}
