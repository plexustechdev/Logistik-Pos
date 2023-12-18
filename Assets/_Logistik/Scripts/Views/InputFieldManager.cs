using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InputFieldManager : MonoBehaviour
{
    [SerializeField] private List<TMP_InputField> _inputFields = new();

    private int _countSelected = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Return))
        {
            _countSelected++;
            if (_countSelected > _inputFields.Count - 1) _countSelected = 0;
            _inputFields[_countSelected].Select();
            print(_countSelected);
        }
    }
}