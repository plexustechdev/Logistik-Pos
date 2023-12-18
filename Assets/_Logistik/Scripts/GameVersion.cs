using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameVersion : MonoBehaviour
{
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
