using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashScreen : MonoBehaviour
{
    public static SplashScreen S;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        if (S == null)
            S = this;
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void Hide()
    {
        canvasGroup.DOFade(0f, 1f).OnComplete(() =>
        {
            canvasGroup.blocksRaycasts = false;
        });
    }

}
