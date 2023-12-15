using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardChildView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberTMP, _nameTMP, _scoreTMP;

    public void SetLeaderboard(string number, string name, string score)
    {
        _numberTMP.text = number;
        _nameTMP.text = name;
        _scoreTMP.text = score;
    }

    public void SetLeaderboard(string number, string name, string score, Color32 color)
    {
        _numberTMP.text = number;
        _nameTMP.text = name;
        _scoreTMP.text = score;

        _numberTMP.color = color;
        _nameTMP.color = color;
        _scoreTMP.color = color;
    }
}
