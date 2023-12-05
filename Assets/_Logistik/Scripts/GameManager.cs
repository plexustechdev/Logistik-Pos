using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public SO_Customer dataCustomer;
    [SerializeField] private CustomerController customerController;

    void Start()
    {
        instance = this;
        customerController.InitaizeCustomer();
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
            SceneManager.LoadSceneAsync(2, LoadSceneMode.Additive);
        }
    }
}
