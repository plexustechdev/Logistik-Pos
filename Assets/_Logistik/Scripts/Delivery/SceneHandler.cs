using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public void btn_BackLoginScene()
    {
        SceneManager.LoadScene("Login");
    }
}
