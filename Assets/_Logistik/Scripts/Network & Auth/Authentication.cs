using System;
using System.Collections;
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

    // private void Start()
    // {
    //     if (AuthenticationSession.GetCachedToken != null)
    //     {
    //         // overworld
    //     }
    // }

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
        request.SetRequestHeader("authorization", "Bearer " + AuthenticationSession.GetCachedToken);

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
    private static string SESSION_TOKEN_KEY = "session_token";

    public static string GetCachedToken => PlayerPrefs.GetString(SESSION_TOKEN_KEY);
    public static void CacheToken(string sessionToken) => PlayerPrefs.SetString(SESSION_TOKEN_KEY, sessionToken);
    public static void ClearCachedToken() => PlayerPrefs.DeleteKey(SESSION_TOKEN_KEY);
}

public enum ErrorCode
{
    NOT_VERIFIED,
    USERNAME_OR_PASSWORD_INVALID
}