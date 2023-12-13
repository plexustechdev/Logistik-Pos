using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingView : MonoBehaviour
{
    [SerializeField] private Image _loadingImage;
    [SerializeField] private Image _motorcycleImage;

    private bool isDoneLoading = false;

    private void OnEnable()
    {
        AnimateBar();
    }

    private void Update()
    {
        _loadingImage.fillAmount += Time.deltaTime * 0.2f;
        AnimateBar();
        if (_loadingImage.fillAmount == 1 && !isDoneLoading)
        {
            GameManager.instance.GoWerehouse();
            isDoneLoading = true;
        }
    }

    private void AnimateBar()
    {
        float width = _loadingImage.GetComponent<RectTransform>().rect.width;
        Vector3 tempV = _motorcycleImage.GetComponent<RectTransform>().anchoredPosition;
        tempV.x = -width / 2;
        tempV.x += width * _loadingImage.fillAmount;
        _motorcycleImage.GetComponent<RectTransform>().anchoredPosition = tempV;
    }

    IEnumerator LoadScene()
    {
        yield return new WaitUntil(() => _loadingImage.fillAmount == 1);

    }
}
