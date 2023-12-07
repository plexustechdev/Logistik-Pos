using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class LogoutView : MonoBehaviour
{
    [SerializeField] private GameObject _loginView, _overworldView;

    private void Start()
    {
        if (AuthenticationSession.GetCachedToken != null)
        {
            SetLogged(true);
        }
        else
        {
            SetLogged(false);
        }
    }

    private void SetLogged(bool isLogin)
    {
        _loginView.SetActive(!isLogin);
        _overworldView.SetActive(isLogin);
    }

    public void Btn_Logout()
    {
        Authentication.instance.GetDataToken(Gateway.URI + Path.Logout, (result) =>
        {
            ResponseLogout response = JsonConvert.DeserializeObject<ResponseLogout>(result);

            if (response.Status == "success")
            {
                AuthenticationSession.ClearCachedToken();
                GameManager.instance.ChangeScene(0);
            }
            else
            {
                print(response.Message);
            }
        });
    }
}
