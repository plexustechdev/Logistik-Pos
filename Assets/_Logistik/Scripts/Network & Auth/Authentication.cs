using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class Authentication : MonoBehaviour
{
    public static Authentication instance;

    private string _url;
    private WWWForm _data;

    private void Awake()
    {
        instance = this;
    }

    private IEnumerator Post(Action<string> callback)
    {
        UnityWebRequest request = UnityWebRequest.Post(_url, _data);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(request.error);
            yield return null;
        }

        callback(request.downloadHandler.text);
    }

    private IEnumerator PostUsingToken(Action<string> callback)
    {
        UnityWebRequest request = UnityWebRequest.Post(_url, _data);
        request.SetRequestHeader("Authorization", "Bearer " + AuthenticationSession.GetCachedToken);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(request.error);
            yield return null;
        }

        callback(request.downloadHandler.text);
    }

    public void PostData(string url, WWWForm data, Action<string> callback)
    {
        _url = url;
        _data = data;
        StartCoroutine(Post(callback));
    }

    public void PostDataToken(string url, WWWForm data, Action<string> callback)
    {
        _url = url;
        _data = data;
        StartCoroutine(PostUsingToken(callback));
    }

    private IEnumerator Get(Action<string> callback)
    {
        UnityWebRequest request = UnityWebRequest.Get(_url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(request.error);
            yield return null;
        }

        callback(request.downloadHandler.text);
    }

    private IEnumerator GetUsingToken(Action<string> callback)
    {
        UnityWebRequest request = UnityWebRequest.Get(_url);
        request.SetRequestHeader("Authorization", "Bearer " + AuthenticationSession.GetCachedToken);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(request.error);
            yield return null;
        }

        callback(request.downloadHandler.text);
    }

    public void GetData(string url, Action<string> callback)
    {
        _url = url;
        StartCoroutine(Get(callback));
    }

    public void GetDataToken(string url, Action<string> callback)
    {
        _url = url;
        StartCoroutine(GetUsingToken(callback));
    }
}

public static class AuthenticationSession
{
    private const string SESSION_TOKEN_KEY = "session_token";

    public static string GetCachedToken => PlayerPrefs.GetString(SESSION_TOKEN_KEY);
    public static void CacheToken(string sessionToken) => PlayerPrefs.SetString(SESSION_TOKEN_KEY, sessionToken);
    public static void ClearCachedToken() => PlayerPrefs.DeleteKey(SESSION_TOKEN_KEY);
    
    public static (string rawKey, string generatedKey) GetKey
    {
        get
        {
            var token = GetCachedToken;
            var tokenLength = token.Length;
            const int tokenCount = 6;

            var resultKey = new StringBuilder();

            for (int i = tokenLength - 1; i >= tokenLength - tokenCount; i--)
            {
                resultKey.Insert(0, token[i]);
            }

            var rawKey = resultKey.ToString();
            var generatedKey = GenerateMD5(rawKey);

            return (rawKey, generatedKey);
        }
    }

    private static string GenerateMD5(string input)
    {
        var md5Hasher = MD5.Create();
        var data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
        var sBuilder = new StringBuilder();
        
        foreach (var t in data)
        {
            sBuilder.Append(t.ToString("x2"));
        }
        
        return sBuilder.ToString();
    }
}



public enum ErrorCode
{
    NOT_VERIFIED,
    USERNAME_OR_PASSWORD_INVALID
}