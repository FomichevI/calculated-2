using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class YandexDataHandler : DataHandler
{
    [DllImport("__Internal")]
    private static extern void InitPlayer();
    [DllImport("__Internal")]
    private static extern void InitYandex();
    [DllImport("__Internal")]
    private static extern void SaveExtern(string data);
    [DllImport("__Internal")]
    private static extern void LoadExtern();
    [DllImport("__Internal")]
    private static extern string GetLanguage();

    private bool _isSdkInit = false;

    public override void Initialize()
    {
        base.Initialize();
        StartCoroutine(Init());
    }
    private IEnumerator Init()
    {
        InitYandex();
        while (!_isSdkInit)
        {
            yield return new WaitForSeconds(.1f);
        }
        InitPlayer();
    }
    public override PlayerData SetData()
    {
        return null;
    }
    public void OnPlayerInitializing()
    {
        Debug.Log("Информация об игроке получена");
        IsInitializing = true;
    }
    public void OnYandexSdkInitializing()
    {
        Debug.Log("SDK инициализирован в юнити");
        _isSdkInit = true;
    }
    public override void StartLoadingPlayerData()
    {
        base.StartLoadingPlayerData();
        LoadExtern();
    }
    public override void SetPlayerData(string value)
    {
        base.SetPlayerData(value);
        if (value != null)
        {
            Debug.Log("Данные игрока найдены на сервере");
            CurrentPlayerData = JsonUtility.FromJson<PlayerData>(value);
        }
        else
        {
            Debug.Log("Данные игрока не были найдены на сервере. Создан новый экземпляр данных");
            CurrentPlayerData = new PlayerData();
        }
        Debug.Log("Проверка. Максимальный пройденный уровень: " + CurrentPlayerData.MaxLevel);
        IsPlayerDataLoading = true;
    }
    public override void SavePlayerData()
    {
        base.SavePlayerData();
        string jsonString = JsonUtility.ToJson(CurrentPlayerData);
        SaveExtern(jsonString);
    }
    public override string GetPlayerLanguage()
    {
        string lang = GetLanguage();
        Debug.Log("Язык игрока получен: " + lang);
        return lang;
    }
}
