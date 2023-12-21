using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderboardChildView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _numberTMP, _nameTMP, _scoreTMP;

    public void SetLeaderboard(string number, string name, int score)
    {
        _numberTMP.text = number;
        _nameTMP.text = name;
        _scoreTMP.text = score.ToString();
    }

    public void SetLeaderboard(string number, string name, int score, Color32 color)
    {
        _numberTMP.text = number;
        _nameTMP.text = name;
        _scoreTMP.text = score.ToString();

        _numberTMP.color = color;
        _nameTMP.color = color;
        _scoreTMP.color = color;
    }
}
