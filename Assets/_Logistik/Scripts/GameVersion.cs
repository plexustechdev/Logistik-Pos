using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameVersion : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _versionTMP;

    private void Awake()
    {
        var version = Application.version;
        _versionTMP.text = $"Version: {version}";

        DontDestroyOnLoad(this);
    }
}
