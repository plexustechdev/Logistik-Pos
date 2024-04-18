using System;
using System.Collections;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public SO_Customer dataCustomer;
    [SerializeField] private CustomerController customerController;
    [SerializeField] private LoadingView loadingView;
    [SerializeField] private GameObject panelLoading;
    private AuthNotifView authNotifView;

    void Start()
    {
        instance = this;
        authNotifView = FindAnyObjectByType<AuthNotifView>();
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
        if (QuestActiveController.ActiveQuest == null) return;
        panelLoading.SetActive(true);
        Authentication.instance.PostDataToken(Gateway.URI + Path.Play + "true", new WWWForm(), (result) =>
        {
            panelLoading.SetActive(false);
            ResponsePlay response = JsonConvert.DeserializeObject<ResponsePlay>(result);
            if (response.Status == "success")
            {
                loadingView.gameObject.SetActive(true);
                Debug.Log("status play");
            }
            else
            {
                authNotifView.SetWarning("Koneksi anda tidak stabil.\nAnda akan kembali ke tampilan login");
            }
        });
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
