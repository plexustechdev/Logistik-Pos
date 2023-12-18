using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueView : MonoBehaviour
{
    public static DialogueView instance;
    [SerializeField] private NarrativeDialogue _dialogueData;
    [SerializeField] private TextMeshProUGUI _dialogueTmp;
    [SerializeField] private Button _btnNext, _btnSkip, _btnPrev;

    private void Awake()
    {
        instance = this;
    }

    private void OnEnable()
    {
        if (QuestActiveController.ActiveQuest is null) return;

        if (QuestActiveController.ActiveQuest.IsFinished && QuestActiveController.ActiveQuest.Level == 10)
            ShowLastDialogue();
        else
            ShowDialogue();
    }

    public void ShowDialogue()
    {
        _dialogueData.SetCount(0);
        CurrentDialogue();
        gameObject.SetActive(true);
    }

    public void ShowLastDialogue()
    {
        ShowButtons(false);

        _dialogueTmp.text = _dialogueData.FinDialogue;
        gameObject.SetActive(true);
    }

    public void OnNextDialogue(GameObject panelDialogue)
    {
        CheckToShowLastDialogue(panelDialogue);
        if (_dialogueData.EndDialogue) DeactivateDialogue(panelDialogue);
        _dialogueTmp.text = _dialogueData.NextDialogue;
        if (!_dialogueData.IsFirstDialog) _btnPrev.gameObject.SetActive(true);
    }

    private void CheckToShowLastDialogue(GameObject panelDialogue)
    {
        if (QuestActiveController.ActiveQuest is null) return;

        if (QuestActiveController.ActiveQuest.IsFinished && QuestActiveController.ActiveQuest.Level == 10) DeactivateDialogue(panelDialogue);
    }

    public void OnPrevDialogue()
    {
        _dialogueTmp.text = _dialogueData.PrevDialogue;
        if (_dialogueData.IsFirstDialog) _btnPrev.gameObject.SetActive(false);
    }

    private void CurrentDialogue()
    {
        ShowButtons(true);

        _dialogueTmp.text = _dialogueData.CurrentDialogue;
        if (_dialogueData.IsFirstDialog) _btnPrev.gameObject.SetActive(false);
    }

    private void DeactivateDialogue(GameObject panelDialogue)
    {
        panelDialogue.SetActive(false);
    }

    private void ShowButtons(bool isShow)
    {
        _btnNext.gameObject.SetActive(isShow);
        _btnPrev.gameObject.SetActive(isShow);
        _btnSkip.gameObject.SetActive(isShow);
    }
}
