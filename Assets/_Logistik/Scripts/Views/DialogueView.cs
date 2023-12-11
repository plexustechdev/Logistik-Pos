using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueView : MonoBehaviour
{
    [SerializeField] private NarrativeDialogue _dialogueData;
    [SerializeField] private TextMeshProUGUI _dialogueTmp;

    private void OnEnable()
    {
        CurrentDialogue();
    }

    public void ShowDialogue()
    {
        CurrentDialogue();
        gameObject.SetActive(true);
    }

    public void OnNextDialogue(GameObject panelDialogue)
    {
        if (_dialogueData.EndDialogue) DeactivateDialogue(panelDialogue);
        _dialogueTmp.text = _dialogueData.NextDialogue;
    }

    public void OnPrevDialogue()
    {
        _dialogueTmp.text = _dialogueData.PrevDialogue;
    }

    private void CurrentDialogue()
    {
        _dialogueTmp.text = _dialogueData.CurrentDialogue;
    }

    private void DeactivateDialogue(GameObject panelDialogue)
    {
        panelDialogue.SetActive(false);
    }
}
