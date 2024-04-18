using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class LogoutView : MonoBehaviour
{
    [SerializeField] private GameObject _loginView, _overworldView, _loadingPanel;

    private void Start()
    {
        if (AuthenticationSession.GetCachedToken != string.Empty)
        {
            SetLogged();
            Authentication.instance.PostDataToken(Gateway.URI + Path.Play + "false", new WWWForm(), (result) =>
            {
                ResponsePlay response = JsonConvert.DeserializeObject<ResponsePlay>(result);
                if (response.Status == "success")
                {
                    Debug.Log("status not play");
                }
                else
                {
                    Debug.Log("error connection");
                }
            });
        }
    }

    private void SetLogged()
    {
        _loginView.SetActive(false);
        _overworldView.SetActive(true);
    }

    public void Btn_Logout()
    {
        _loadingPanel.SetActive(true);

        Authentication.instance.GetDataToken(Gateway.URI + Path.Logout, (result) =>
        {
            _loadingPanel.SetActive(false);

            ResponseLogout response = JsonConvert.DeserializeObject<ResponseLogout>(result);

            if (response.Status == "success")
            {
                AuthenticationSession.ClearCachedToken();
                GameManager.instance.ChangeScene(0);
            }
            else
            {
                AuthenticationSession.ClearCachedToken();
                GameManager.instance.ChangeScene(0);
            }
        });
    }
}
