using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestLevel", menuName = "Quest/Level", order = 0)]
public class SO_QuestLevel : ScriptableObject
{
    [SerializeField] private int _level;
    [SerializeField] private float _goodsAmount;
    [SerializeField] private string _description;
    [SerializeField] private string _destination;
    public bool IsQuestActive = false;

    public int Level => _level;
    public float GoodsAmount => _goodsAmount;
    public string Description => _description;
    public string Destination => _destination;
}
