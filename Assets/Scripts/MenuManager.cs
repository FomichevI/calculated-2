using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum eThemeType { black, blue, white }

public class MenuManager : MonoBehaviour
{
    public static MenuManager S;
    public bool isMenu;
    [Header("Для сцены меню")]
    public GameObject settingsPanel;
    public GameObject updatePanel;
    public GameObject soundOnImage;
    public GameObject soundOffImage;
    public GameObject musicOnImage;
    public GameObject musicOffImage;
    public GameObject russianLangLightning;
    public GameObject englishLangLightning;
    public GameObject blackThemeLightning;
    public GameObject blueThemeLightning;
    public GameObject whiteThemeLightning;

    public Slider musicSlider;
    public Slider volumeSlider;

    private bool isItitCompleted = false;
    [Header("Для сцены уровня")]
    public GameObject rulesPanel;
    public GameObject winPanel;
    public GameObject hintPanel;
    public GameObject waitPanel;

    public bool soundOn = true;
    public bool musicOn = true;

    public bool panelsIsActive;

    private float soundVolume;
    private float musicVolume;

    private void Awake()
    {
        if (S == null)
            S = this;
    }

    public void Init()
    {
        soundVolume = SaveController.S.GetVolume();
        musicVolume = SaveController.S.GetMusic();
        AudioManager.S.Init();
        if (isMenu)
        {
            if (SaveController.S.GetVolumeOn() == 0)
                SwitchSound();
            else
                volumeSlider.value = soundVolume;
            if (SaveController.S.GetMusicOn() == 0)
                SwitchMusic();
            else
                musicSlider.value = musicVolume;
            SetLanguageLightning(SaveController.S.GetLanguage());
            MenuCreater.S.Init();
        }
        SetLanguage(SaveController.S.GetLanguage());
        isItitCompleted = true;
        SplashScreen.S.Hide();
    }

    //методы для сцены меню
    #region Menu
    public void ShowSettings()
    {
        settingsPanel.SetActive(true);
        AudioManager.S.PlayClick();
    }
    public void ShowUpdatePanel()
    {
        updatePanel.SetActive(true);
    }
    public void HideSettings()
    {
        settingsPanel.SetActive(false);
        AudioManager.S.PlayClick();
    }
    public void HideUpdatePanel()
    {
        updatePanel.SetActive(false);
        AudioManager.S.PlayClick();
    }
    //public void DownloadUpdates()
    //{
    //    HideUpdatePanel();
    //    Application.OpenURL("https://play.google.com/store/apps/details?id=com.HappyRussianGames.Calculated");
    //}
    public void SwitchSound()
    {
        if (soundOn)
        {
            soundOnImage.SetActive(false);
            soundOffImage.SetActive(true);
            soundOn = false;
            if(isItitCompleted)
                SaveController.S.SetVolumeOn(0);
            AudioManager.S.SetVolume(0);
            volumeSlider.value = 0;
        }
        else
        {
            soundOnImage.SetActive(true);
            soundOffImage.SetActive(false);
            soundOn = true;
            if (isItitCompleted)
                SaveController.S.SetVolumeOn(1);
            AudioManager.S.SetVolume(soundVolume);
            volumeSlider.value = soundVolume;
        }
    }
    public void SwitchMusic()
    {
        if (musicOn)
        {
            musicOnImage.SetActive(false);
            musicOffImage.SetActive(true);
            musicOn = false;
            if (isItitCompleted)
                SaveController.S.SetMusicOn(0);
            AudioManager.S.SetMusicVolume(0);
            musicSlider.value = 0;
        }
        else
        {
            musicOnImage.SetActive(true);
            musicOffImage.SetActive(false);
            musicOn = true;
            if (isItitCompleted)
                SaveController.S.SetMusicOn(1);
            AudioManager.S.SetMusicVolume(musicVolume);
            musicSlider.value = musicVolume;
        }
    }

    public void SetSoundVolume()
    {
        if (volumeSlider.value != 0)
        {
            float val = volumeSlider.value;
            if (soundOn && val == 0) //если звук включен, но мы убавляем на 0
                SwitchSound();
            else if (!soundOn && val != 0) //если звук выключен, а мы его включаем
            {
                soundVolume = val;
                SwitchSound();
            }
            else //если звук включен и мы его меняем
            {
                soundVolume = val;
                AudioManager.S.SetVolume(val);
            }
        }
    }
    public void SetMusicVolume()
    {
        if (musicSlider.value != 0)
        {
            float val = musicSlider.value;
            if (musicOn && val == 0) //если звук включен, но мы убавляем на 0
                SwitchMusic();
            else if (!musicOn && val != 0) //если звук выключен, а мы его включаем
            {
                musicVolume = val;
                SwitchMusic();
            }
            else //если звук включен и мы его меняем
            {
                musicVolume = val;
                AudioManager.S.SetMusicVolume(val);
            }
        }
    }
    public void SetLanguage(string lang)
    {
        GetComponent<LanguageManager>().SetAllTexts(lang);
    }
    public void SetLanguageLightning(string lang)
    {
        if (lang == "ru")
        {
            englishLangLightning.SetActive(false);
            russianLangLightning.SetActive(true);
        }
        else if (lang == "en")
        {
            englishLangLightning.SetActive(true);
            russianLangLightning.SetActive(false);
        }
        if (isItitCompleted)
            SaveController.S.SetLanguage(lang);
    }
    public void SaveVolumes()
    {
        if (isItitCompleted)
        {
            SaveController.S.SetVolumes(musicVolume, soundVolume);
        }
    }
    #endregion
    //методы для сцены уровня
    #region Level
    public void ShowRules()
    {
        rulesPanel.SetActive(true);
        GetComponent<GameManager>().isPlaying = false;
        AudioManager.S.PlayClick();
        panelsIsActive = true;
    }
    public void HideRules()
    {
        rulesPanel.SetActive(false);
        GetComponent<GameManager>().isPlaying = true;
        AudioManager.S.PlayClick();
        panelsIsActive = false;
    }
    public void ShowWaitPanel()
    {
        waitPanel.SetActive(true);
        GetComponent<GameManager>().isPlaying = false;
        panelsIsActive = true;
    }
    public void HideWaitPanel()
    {
        waitPanel.SetActive(false);
        GetComponent<GameManager>().isPlaying = true;
        AudioManager.S.PlayClick();
        panelsIsActive = false;
    }
    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
        GetComponent<GameManager>().isPlaying = false;
        AudioManager.S.PlayClick();
    }
    public void ContinuePlay()
    {
        winPanel.SetActive(false);
        SaveController.S.SetCurrentLevel(GetComponent<GameManager>().currentLvl + 1);
        if (GetComponent<GameManager>().currentLvl == 99)
        {
            DataManager.S.LoadMenuScene();
        }
        else
        {
            AdvertismentManager.S.ShowInterstitial();
            SceneManager.LoadScene(2);
        }
        AudioManager.S.PlayClick();
    }
    public void ShowHintPanel()
    {
        hintPanel.SetActive(true);
        GetComponent<GameManager>().isPlaying = false;
        AudioManager.S.PlayClick();
        panelsIsActive = true;
    }
    public void HideHintPanel()
    {
        hintPanel.SetActive(false);
        GetComponent<GameManager>().isPlaying = true;
        AudioManager.S.PlayClick();
        panelsIsActive = false;
    }
    public void ShowHint()
    {
        GetComponent<GameManager>().isPlaying = true;
        hintPanel.SetActive(false);
        AdvertismentManager.S.ShowRevarded(() => GetComponent<GameManager>().ShowNewHint());
    }
    public void BackToMenu()
    {
        AudioManager.S.PlayClick();
        DataManager.S.LoadMenuScene();
    }
    #endregion
    public void PlayClick()
    {
        AudioManager.S.PlayClick();
    }
}
