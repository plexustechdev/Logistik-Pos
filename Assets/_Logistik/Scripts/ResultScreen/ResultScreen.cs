using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultScreen : MonoBehaviour
{
    public GameObject successScreen;
    public GameObject failedScreen;

    public void ShowSuccess(bool val){
        successScreen.SetActive(val);
        failedScreen.SetActive(!val);
    }
}
