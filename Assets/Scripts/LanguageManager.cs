
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LanguageManager : MonoBehaviour
{
    public bool isMenu;

    [Header("Пункты для меню")]
    public TMP_Text soundText;
    public TMP_Text musicText;
    public TMP_Text languageText;
    public TMP_Text themeText;
    public TMP_Text menuText;
    public TMP_Text needDownloadText;
    public TMP_Text downloadText;

    [Header("Пункты для уровня")]
    public TMP_Text scoreText;
    public TMP_Text rulesText;
    public TMP_Text waitText;
    public TMP_Text[] menuTextsLevel;
    public TMP_Text[] resumeTexts;
    public TMP_Text winText;
    public TMP_Text hintText;
    public TMP_Text yesText;
    public TMP_Text noText;


    public void SetAllTexts(string lang)
    {
        if (lang == "ru")
        {
            if (isMenu)
            {
                soundText.text = "Звук";
                musicText.text = "Музыка";
                languageText.text = "Язык";
                themeText.text = "Тема";
                menuText.text = "В меню";
                downloadText.text = "Обновить";
                needDownloadText.text = "Доступна новая версия игры!";
            }
            else
            {
                scoreText.text = "Счет";
                rulesText.text = "Пройдите лабиринт таким образом, чтобы итоговое число совпадало с числом на финишной клетке";
                foreach (TMP_Text t in menuTextsLevel)
                    t.text = "В меню";
                foreach (TMP_Text t in resumeTexts)
                    t.text = "Далее";
                winText.text = "Поздравляем!\nВы прошли уровень!";
                hintText.text = "Хотите просмотреть короткое видео, чтобы получить подсказку?";
                yesText.text = "Да";
                noText.text = "Нет";
                waitText.text = "Реклама еще не загрузилась. Подождите немного";
            }
        }

        else
        {
            if (isMenu)
            {
                soundText.text = "Sound";
                musicText.text = "Music";
                languageText.text = "Language";
                themeText.text = "Theme";
                menuText.text = "Menu";
                downloadText.text = "Download";
                needDownloadText.text = "A new version of the game is available!";
            }
            else
            {
                scoreText.text = "Score";
                rulesText.text = "Complete the maze so that your final score is equal to the number on the finish square";
                foreach (TMP_Text t in menuTextsLevel)
                    t.text = "Menu";
                foreach (TMP_Text t in resumeTexts)
                    t.text = "Resume";
                winText.text = "Congratulations!\nYou complete this level!";
                hintText.text = "Want to watch a short video to get a hint?";
                yesText.text = "Yes";
                noText.text = "No";
                waitText.text = "The video hasn't loaded yet. Please wait a bit";
            }
        }
    }

}
