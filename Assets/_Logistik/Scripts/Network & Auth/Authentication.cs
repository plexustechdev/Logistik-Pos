using System;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class Authentication : MonoBehaviour
{
    private string _url;
    private WWWForm _data;
    private Response _response;

    public Response GetResponse => _response;

    private IEnumerator Post()
    {
        UnityWebRequest request = UnityWebRequest.Post(_url, _data);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError) Debug.Log(request.error);

        var result = JsonConvert.DeserializeObject<Response>(request.downloadHandler.text);

        _response = result;
    }

    public void PostData(string url, WWWForm data)
    {
        _url = url;
        _data = data;

        StartCoroutine(Post());
    }
}

[Serializable]
public class Response
{
    public string Status;
    public string Message;
    public User GetUser;
}

[Serializable]
public class User
{
    public string Id;
    public string Username;
    public string PhoneNumber;
    public string Email;
    public string Token;
}