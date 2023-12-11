using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideView : MonoBehaviour
{
    public static GuideView instance;

    [SerializeField] private GameObject _guideOffice, _guideOverworld;

    private void Start()
    {
        instance = this;
    }

    public void GuideOffice()
    {
        if (QuestActiveController.ActiveQuest != null)
        {
            _guideOffice.SetActive(true);
            _guideOverworld.SetActive(false);
        }
    }

    public void GuideOverworld()
    {
        if (QuestActiveController.ActiveQuest != null)
        {
            _guideOverworld.SetActive(true);
            _guideOffice.SetActive(false);
        }
    }

    public void DeactivateGuide()
    {
        _guideOffice.SetActive(false);
        _guideOverworld.SetActive(false);
    }
}
