using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueView : MonoBehaviour
{
    [SerializeField] private NarrativeDialogue _dialogueData;
    [SerializeField] private TextMeshProUGUI _dialogueTmp;

    private bool isShowing = true;

    private void OnEnable()
    {
        ShowDialogue();
    }

    public void OnNextDialogue(GameObject panelDialogue)
    {
        if (!_dialogueData.EndDialogue) _dialogueTmp.text = _dialogueData.GetDialogue;
        else DeactivateDialogue(panelDialogue);
    }

    public void ShowDialogue()
    {
        if (isShowing) _dialogueTmp.text = _dialogueData.GetDialogue;
    }

    public void DeactivateDialogue(GameObject panelDialogue)
    {
        isShowing = false;
        panelDialogue.SetActive(false);
    }
}
