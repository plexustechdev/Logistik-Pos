using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandlerView : MonoBehaviour
{
    public void btn_BackLoginScene()
    {
        GameManager.instance.ChangeSceneNormal(0);
    }

    public void btn_RestartLevel()
    {
        GameManager.instance.GoWerehouse();
    }
}
