
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ThemeChanger : MonoBehaviour
{
    public Sprite frame1;
    public Sprite frame2;
    public bool isMenu;
    [Header("Для сцены меню")]
    public Image mainMenuBgImg;
    public Image[] menuFrames;
    public Image[] additionalMenuBgImgs;

    [Header("Для сцены уровня")]
    public Image mainLevelBgImg;
    public Image[] levelFrames;
    public Image[] additionalLevelBgImgs;
    public TMP_Text scoreText;



    private Color mainBgTheme1Col;
    private Color mainBgTheme2Col;
    private Color mainBgTheme3Col;

    private Color additionalBgTheme13Col;
    private Color additionalBgTheme2Col;

    void Start()
    {
        mainBgTheme1Col = new Color(65 / 255f, 65 / 255f, 65 / 255f);
        mainBgTheme2Col = new Color(35 / 255f, 135 / 255f, 1);
        mainBgTheme3Col = Color.white;
        additionalBgTheme13Col = Color.white;
        additionalBgTheme2Col = new Color(0, 190 / 255f, 230 / 255f);        

        SetTheme(GetComponent<SaveController>().GetTheme());
    }

    public void SetTheme(int theme)
    {
        if (isMenu)
        {
            if (theme >= 1 && theme <= 3)
            {
                switch (theme)
                {
                    case 1:
                        mainMenuBgImg.color = mainBgTheme1Col;
                        foreach (Image im in additionalMenuBgImgs)
                            im.color = additionalBgTheme13Col;
                        foreach (Image im in menuFrames)
                            im.sprite = frame1;
                        break;
                    case 2:
                        mainMenuBgImg.color = mainBgTheme2Col;
                        foreach (Image im in additionalMenuBgImgs)
                            im.color = additionalBgTheme2Col;
                        foreach (Image im in menuFrames)
                            im.sprite = frame2;
                        break;
                    case 3:
                        mainMenuBgImg.color = mainBgTheme3Col;
                        foreach (Image im in additionalMenuBgImgs)
                            im.color = additionalBgTheme13Col;
                        foreach (Image im in menuFrames)
                            im.sprite = frame1;
                        break;
                }
            }
        }
        else
        {
            if (theme >= 1 && theme <= 3)
            {
                switch (theme)
                {
                    case 1:
                        mainLevelBgImg.color = mainBgTheme1Col;
                        foreach (Image im in additionalLevelBgImgs)
                            im.color = additionalBgTheme13Col;
                        foreach (Image im in levelFrames)
                            im.sprite = frame1;
                        scoreText.color = Color.white;
                        break;
                    case 2:
                        mainLevelBgImg.color = mainBgTheme2Col;
                        foreach (Image im in additionalLevelBgImgs)
                            im.color = additionalBgTheme2Col;
                        foreach (Image im in levelFrames)
                            im.sprite = frame2;
                        scoreText.color = Color.white;
                        break;
                    case 3:
                        mainLevelBgImg.color = mainBgTheme3Col;
                        foreach (Image im in additionalLevelBgImgs)
                            im.color = additionalBgTheme13Col;
                        foreach (Image im in levelFrames)
                            im.sprite = frame1;
                        scoreText.color = Color.black;
                        break;
                }
            }
        }
    }
}
