using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataManager : MonoBehaviour
{
    public static DataManager S;
    [SerializeField] private DataHandler _currentDataHandler;
    private bool _isGameFirstLoaded = false;

    private void Awake()
    {
        if (S == null)
            S = this;
    }
    void Start()
    {
        DontDestroyOnLoad(gameObject);
#if UNITY_EDITOR
        _currentDataHandler = null;
#endif
        SceneManager.LoadScene(1);
        StartCoroutine(Starting());
    }
    private IEnumerator Starting()
    {
        yield return new WaitForSeconds(.05f);
        while (SaveController.S == null || MenuManager.S == null)
            yield return new WaitForSeconds(.1f);
        if (!_isGameFirstLoaded)
        {
            SaveController.S.Init();
            if (_currentDataHandler != null)
            {
                _currentDataHandler.Initialize();
                while (!_currentDataHandler.IsInitializing)
                {
                    yield return new WaitForSeconds(.1f);
                }
                _currentDataHandler.StartLoadingPlayerData();
                while (!_currentDataHandler.IsPlayerDataLoading)
                {
                    yield return new WaitForSeconds(.1f);
                }
                SaveController.S.LoadData(_currentDataHandler.CurrentPlayerData);
                _isGameFirstLoaded = true;
            }
        }
        MenuManager.S.Init();
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene(1);
        StartCoroutine(Starting());
    }
    #region Saves
    public void SetMaxLevel(int level)
    {
        if (_currentDataHandler != null && _currentDataHandler.CurrentPlayerData != null)
        {
            _currentDataHandler.CurrentPlayerData.MaxLevel = level;
            _currentDataHandler.SavePlayerData();
        }
    }
    public void SetVolume(float volume)
    {
        if (_currentDataHandler != null && _currentDataHandler.CurrentPlayerData != null)
        {
            _currentDataHandler.CurrentPlayerData.VolumeLevel = volume;
            _currentDataHandler.SavePlayerData();
        }
    }
    public void SetMusic(float volume)
    {
        if (_currentDataHandler != null && _currentDataHandler.CurrentPlayerData != null)
        {
            _currentDataHandler.CurrentPlayerData.MusicLevel = volume;
            _currentDataHandler.SavePlayerData();
        }
    }
    public void SetLanguage(string lang)
    {
        if (_currentDataHandler != null && _currentDataHandler.CurrentPlayerData != null)
        {
            _currentDataHandler.CurrentPlayerData.Language = lang;
            _currentDataHandler.SavePlayerData();
        }
    }
    public void SetVolumeOn(bool isOn)
    {
        if (_currentDataHandler != null && _currentDataHandler.CurrentPlayerData != null)
        {
            _currentDataHandler.CurrentPlayerData.VolumeOn = isOn;
            _currentDataHandler.SavePlayerData();
        }
    }
    public void SetMusicOn(bool isOn)
    {
        if (_currentDataHandler != null && _currentDataHandler.CurrentPlayerData != null)
        {
            _currentDataHandler.CurrentPlayerData.MusicOn = isOn;
            _currentDataHandler.SavePlayerData();
        }
    }
    #endregion
}
