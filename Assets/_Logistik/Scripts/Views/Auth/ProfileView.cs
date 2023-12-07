using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

public class ProfileView : MonoBehaviour
{
    [SerializeField] private GameObject _profileObj;
    [SerializeField] private TextMeshProUGUI _nameTMP;
    [SerializeField] private TextMeshProUGUI _walletTMP;

    public void Btn_GetProfile()
    {
        Authentication.instance.GetDataToken(Gateway.URI + Path.GetProfile, (result) =>
        {
            ResponseProfile response = JsonConvert.DeserializeObject<ResponseProfile>(result);
            if (response.Status == "success")
            {
                _nameTMP.text = response.Data.Username;
            }
            else
            {
                print(response.Status);
            }
        });

        Authentication.instance.GetDataToken(Gateway.URI + Path.Wallets, (result) =>
        {
            ResponseWallet response = JsonConvert.DeserializeObject<ResponseWallet>(result);
            if (response.Status == "success")
            {
                _walletTMP.text = response.Total_wallet + "/1000000";
            }
            else
            {
                _walletTMP.text = "0/1000000";
            }
            _profileObj.SetActive(true);
        });
    }
}
