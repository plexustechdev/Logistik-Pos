using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Test : MonoBehaviour
{
    IEnumerator Start()
    {
        var _url = Gateway.URI + Path.Login;
        WWWForm _data = new WWWForm();

        _data.AddField("username", "beplexus");
        _data.AddField("password", "password");

        UnityWebRequest request = UnityWebRequest.Post(_url, _data);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError)
        {
            Debug.Log(request.error);
            yield return null;
        }

        // var result = JsonConvert.DeserializeObject<ResponsePost>(request.downloadHandler.text);

        // _responsePost = result;
    }
}
