using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Start()
    {
        instance = this;
    }

    public void ChangeScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }

    public void GoWerehouse()
    {
        if (QuestActiveController.ActiveQuest != null)
        {
            ChangeScene(1);
        }
    }
}
