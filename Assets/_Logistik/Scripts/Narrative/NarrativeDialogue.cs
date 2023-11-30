using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeDialogue : MonoBehaviour
{
    [TextArea][SerializeField] private List<string> _dialogueList = new List<string>();
    private int count = 0;

    public string GetDialogue
    {
        get
        {
            var dialogue = _dialogueList[count];
            count++;
            return dialogue;
        }
    }

    public bool EndDialogue
    {
        get
        {
            if (count > _dialogueList.Count - 1) return true;
            return false;
        }
    }
}
