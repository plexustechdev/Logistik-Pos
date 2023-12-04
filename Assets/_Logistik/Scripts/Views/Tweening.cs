using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Tweening : MonoBehaviour
{
    public IEnumerator ShowCustomer(Transform target, Transform startPos, Transform endPos, Image character, Image dialogueBox)
    {
        HideCustomer(character, dialogueBox);
        yield return new WaitForSeconds(0.1f);

        target.position = new Vector2(startPos.position.x, target.position.y);
        yield return new WaitForSeconds(0.2f);
        target.DOMoveX(endPos.position.x, 0.2f);
        character.DOFade(1, 0.2f);
        yield return new WaitForSeconds(0.6f);
        dialogueBox.gameObject.transform.DOScale(1, 0.5f);
        yield return new WaitForSeconds(0.25f);
    }

    public void HideCustomer(Image character, Image dialogueBox)
    {
        character.DOFade(0, 0.01f);
        dialogueBox.gameObject.transform.DOScale(0, 0.1f);
    }
}
