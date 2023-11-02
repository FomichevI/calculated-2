
using System.Collections;
using UnityEngine;
using System;

public class AdvertismentManager : MonoBehaviour
{
    public static AdvertismentManager S;
    [SerializeField] private AdsService _adsService;

    [SerializeField] private float _secondsBetweenInterstitial = 180;
    private float _lastShowInterstitial = 0;
    private Action _onRevarded;

    private void Awake()
    {
       if (S == null) 
            S = this;
        _lastShowInterstitial = Time.time;
    }
    public void ShowRevarded(Action action)
    {
#if UNITY_EDITOR
        action.Invoke();
        return;
#endif
        Debug.Log("Show Revarded");
        _onRevarded += action;
        AudioManager.S.StopAllSounds();
        _adsService.ShowRevarded();
    }
    public void ShowInterstitial()
    {
#if UNITY_EDITOR
        Debug.Log("Show Interstitial");
        return;
#endif
        if (Time.time - _lastShowInterstitial > _secondsBetweenInterstitial)
        {
            Debug.Log("Show Interstitial");
            _adsService.ShowInterstitial();
            AudioManager.S.StopAllSounds();
            _lastShowInterstitial = Time.time;
        }
        else
        {
            Debug.Log("Time to next Interstitial: " + (_secondsBetweenInterstitial - (Time.time - _lastShowInterstitial)));
        }
    }
    public void ContinuePlaySound()
    {
        AudioManager.S.StartAllSounds();
    }
    public void Revard()
    {
        _onRevarded?.Invoke();
        _onRevarded = null;
    }
}
