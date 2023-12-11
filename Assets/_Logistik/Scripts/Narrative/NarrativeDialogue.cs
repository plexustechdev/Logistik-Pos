using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeDialogue : MonoBehaviour
{
    [TextArea][SerializeField] private List<string> _dialogueList = new List<string>();
    private int count = 0;

    public string CurrentDialogue => _dialogueList[0];

    public string NextDialogue
    {
        get
        {
            count++;
            if (count >= _dialogueList.Count) count = _dialogueList.Count - 1;
            var dialogue = _dialogueList[count];

            return dialogue;
        }
    }

    public string PrevDialogue
    {
        get
        {
            count--;
            if (count < 0) count = 0;
            var dialogue = _dialogueList[count];

            return dialogue;
        }
    }

    public bool EndDialogue
    {
        get
        {
            if (count == _dialogueList.Count - 1) return true;
            return false;
        }
    }
}
