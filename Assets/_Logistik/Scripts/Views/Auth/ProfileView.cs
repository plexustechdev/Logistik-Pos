using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfileView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _nameTMP;
    [SerializeField] private TextMeshProUGUI _walletTMP;
    [SerializeField] private TextMeshProUGUI _usernameLabel;
    [SerializeField] private TextMeshProUGUI _levelLabel;
    [SerializeField] private Image _levelBar;

    [Header("View")]
    [SerializeField] private GameObject _officeView;
    [SerializeField] private GameObject _officeDialogue;
    [SerializeField] private GameObject _loadingView;
    [SerializeField] private SettingView _settingView;

    private int _playerExp;

    public void Btn_GetProfile()
    {
        _loadingView.gameObject.SetActive(true);

        Authentication.instance.GetDataToken(Gateway.URI + Path.GetProfile, (result) =>
        {
            ResponseProfile response = JsonConvert.DeserializeObject<ResponseProfile>(result);
            if (response.Status == "success")
            {
                _nameTMP.text = response.Data.Username;
                _usernameLabel.text = response.Data.Username;
            }
            else
            {
                print(response.Status);
            }
        });

        Authentication.instance.GetDataToken(Gateway.URI + Path.Wallets, (result) =>
        {
            _settingView.OfficePosView();
            _loadingView.gameObject.SetActive(false);
            _officeDialogue.gameObject.SetActive(true);
            GuideView.instance.GuideOffice();

            ResponseWallet response = JsonConvert.DeserializeObject<ResponseWallet>(result);

            _playerExp = (int)float.Parse(response.Total_wallet);

            if (response.Status == "success")
            {
                _levelLabel.text = "LV. " + SetLevel().currentLevel.ToString();
                _walletTMP.text = _playerExp + "/" + SetLevel().maxLevel.ToString();
                _levelBar.fillAmount = (float)_playerExp / (float)SetLevel().maxLevel;
            }
            else
            {
                _walletTMP.text = 0 + "/" + SetLevel().maxLevel.ToString();
            }

            _officeView.SetActive(true);
        });
    }

    private (int currentLevel, int maxLevel) SetLevel()
    {
        int _currentLevel = _playerExp switch
        {
            0 => 0,
            > 0 and < 10 => 1,
            >= 10 and < 40 => 2,
            >= 40 and < 60 => 3,
            >= 60 and < 100 => 4,
            >= 100 and < 140 => 5,
            >= 140 and < 220 => 6,
            >= 220 and < 290 => 7,
            >= 290 and < 430 => 8,
            >= 430 and < 530 => 9,
            >= 530 => 10
        };

        int _maxLevel = _currentLevel switch
        {
            0 => 0,
            1 => 10,
            2 => 40,
            3 => 60,
            4 => 100,
            5 => 140,
            6 => 220,
            7 => 290,
            8 => 430,
            9 => 530,
            10 => 530
        };

        return (currentLevel: _currentLevel, maxLevel: _maxLevel);
    }
}
