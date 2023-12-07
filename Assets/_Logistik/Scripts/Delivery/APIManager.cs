using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class APIManager : MonoBehaviour
{
    public string url = Gateway.URI;
    [SerializeField] private string TOKEN;

    public void PostEXP(int score)
    {
        WWWForm form = new WWWForm();
        form.AddField("amount", score);
        StartCoroutine(OnPostEXP(form));
    }

    IEnumerator OnPostEXP(WWWForm form)
    {
        using (UnityWebRequest request = UnityWebRequest.Post(string.Format("{0}wallets", url), form))
        {
            request.SetRequestHeader("Authorization", "Bearer " + AuthenticationSession.GetCachedToken);
            yield return request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError(request.error);
            }
            else
            {
                Debug.LogError("Post Complete");
            }
        }
    }
}
