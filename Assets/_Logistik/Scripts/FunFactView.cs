using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FunFactView : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _funFactTMP;

    [Header("Fun Fact Data")]
    [TextArea]
    [SerializeField] private List<string> _funFacts = new();

    private void OnEnable()
    {
        RandomFunFact();
    }

    private void RandomFunFact()
    {
        if (_funFacts is null) return;

        int randomNum = Random.Range(0, _funFacts.Count - 1);
        _funFactTMP.text = _funFacts[randomNum];
    }
}
