using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingView : MonoBehaviour
{
    [SerializeField] private Image _loadingImage;

    private void Update()
    {
        _loadingImage.fillAmount += Time.deltaTime * 0.5f;
    }
}
