using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public SO_Customer dataCustomer;
    [SerializeField] private CustomerController customerController;
    [SerializeField] private LoadingView loadingView;

    void Start()
    {
        instance = this;
        // customerController.InitaizeCustomer();
    }

    public void ChangeScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }

    public void UnloadScene(int index)
    {
        SceneManager.UnloadSceneAsync(index);
    }

    public void GoWerehouse()
    {
        if (QuestActiveController.ActiveQuest != null)
        {
            ChangeScene(1);
            SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        }
    }

    public void ChangeSceneNormal(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void Btn_LoadingCanvas()
    {
        if (QuestActiveController.ActiveQuest != null)
            loadingView.gameObject.SetActive(true);
    }

    public IEnumerator ChangeSceneAsync(Action waitLoading)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(0);

        while (!loadOperation.isDone)
        {
            waitLoading();
            yield return null;
        }
    }
}
