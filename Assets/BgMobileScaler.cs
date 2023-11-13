using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgMobileScaler : MonoBehaviour
{
    private RectTransform _rect;

    private void Start()
    {
        _rect = GetComponent<RectTransform>();
        if (_rect != null)
        {
            if(Screen.width < Screen.height)
                _rect.sizeDelta = new Vector2(Screen.width + 50, Screen.height + 50);
        }
    }
}
