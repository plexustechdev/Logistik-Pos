using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProfileView : MonoBehaviour
{
    [Header("Dependency")]
    [SerializeField] private CustomerController customerController;

    [Header("Property")]
    [SerializeField] private TextMeshProUGUI _nameTMP;
    [SerializeField] private TextMeshProUGUI _walletTMP;
    [SerializeField] private TextMeshProUGUI _usernameLabel;
    [SerializeField] private TextMeshProUGUI _levelLabel;
    [SerializeField] private TextMeshProUGUI _levelLabelPanel;
    [SerializeField] private Image _levelBar;

    [Header("View")]
    [SerializeField] private GameObject _officeView;
    [SerializeField] private GameObject _officeDialogue;
    [SerializeField] private GameObject _loadingView;

    private int _playerExp;

    public void Btn_GetProfile()
    {
        _loadingView.SetActive(true);

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
                AuthenticationSession.ClearCachedToken();
                GameManager.instance.ChangeScene(0);
            }
        });

        Authentication.instance.GetDataToken(Gateway.URI + Path.Wallets, (result) =>
        {
            _loadingView.SetActive(false);
            _officeDialogue.SetActive(true);
            GuideView.instance.GuideOffice();

            ResponseWallet response = JsonConvert.DeserializeObject<ResponseWallet>(result);

            var culture = CultureInfo.InvariantCulture;
            _playerExp = (int)float.Parse(response.Total_wallet, culture);
            print(response.Total_wallet);

            if (response.Status == "success")
            {
                int level = SetLevel().currentLevel;
                QuestActiveController.currentLevel = level;
                customerController.InitaizeCustomer();
                
                string showLevel = "LV. " + level.ToString();
                _levelLabel.text = showLevel;
                _levelLabelPanel.text = showLevel;

                _walletTMP.text = _playerExp + "/" + SetLevel().maxLevel.ToString();
                _levelBar.fillAmount = (float)_playerExp / (float)SetLevel().maxLevel;
            }
            else
            {
                print(response.Status);
                AuthenticationSession.ClearCachedToken();
                GameManager.instance.ChangeScene(0);
            }

            _officeView.SetActive(true);
        });
    }

    private (int currentLevel, int maxLevel) SetLevel()
    {
        int _currentLevel = _playerExp switch
        {
            >= 0 and < 10 => 1,
            >= 10 and < 40 => 2,
            >= 40 and < 60 => 3,
            >= 60 and < 100 => 4,
            >= 100 and < 140 => 5,
            >= 140 and < 220 => 6,
            >= 220 and < 290 => 7,
            >= 290 and < 430 => 8,
            >= 430 and < 530 => 9,
            >= 530 => 10,
            _ => 0
        };

        int _maxLevel = _currentLevel switch
        {
            1 => 10,
            2 => 40,
            3 => 60,
            4 => 100,
            5 => 140,
            6 => 220,
            7 => 290,
            8 => 430,
            9 => 530,
            10 => 530,
            _ => 0
        };

        return (currentLevel: _currentLevel, maxLevel: _maxLevel);
    }
}
