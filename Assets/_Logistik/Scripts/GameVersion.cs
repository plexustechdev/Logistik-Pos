using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameVersion : MonoBehaviour
{
    public static GameVersion instance;
    [SerializeField] private TextMeshProUGUI _versionTMP;

    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(this);
        else
            instance = this;

        DontDestroyOnLoad(this);

        string version = Application.version;
        _versionTMP.text = $"Version: {version}";
    }
}
