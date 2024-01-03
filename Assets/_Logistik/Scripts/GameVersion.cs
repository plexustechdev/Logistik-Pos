using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System.Runtime.InteropServices;

public class GameVersion : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string GetBaseUrl();

    public static GameVersion instance;
    [SerializeField] private TextMeshProUGUI _versionTMP;
    [SerializeField] private GameObject _popUpUnconnected;

    private void Awake()
    {
        if (instance != null && instance != this) Destroy(this);
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }

        Gateway.SetUri(GetBaseUrl());
        string version = Application.version;
        _versionTMP.text = $"Version: {version}";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Delete))
        {
            Reset();
        }

        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            _popUpUnconnected.SetActive(true);
        }
    }

    public void Reset()
    {
        _popUpUnconnected.SetActive(false);
        AuthenticationSession.ClearCachedToken();
        GameManager.instance.ChangeScene(0);
    }
}
