using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuCreater : MonoBehaviour
{
    public static MenuCreater S;

    public Transform contentTrans;
    public GameObject levelButtonPrefab;
    public LevelButton currentLevelBut;

    [SerializeField] private Color passedCol;
    [SerializeField] private Color notOpenCol;
    private Color currentCol;

    private void Awake()
    {
        if (S == null)
            S = this;
    }

    public void Init()
    {
        currentCol = Color.clear;

        int maxCompleteLevel = GetComponent<SaveController>().GetMaxLevel();
        //меняем значение большой кнопки
        currentLevelBut.SetValue(maxCompleteLevel);

        for (int i = 1; i<100; i++)
        {
            //создать кнопку
            GameObject button = Instantiate<GameObject>(levelButtonPrefab);
            LevelButton levelButton = button.GetComponent<LevelButton>();
            button.transform.SetParent(contentTrans);
            button.transform.localScale = Vector3.one;
            //изменить ее значение
            levelButton.SetValue(i);
            //изменить цвет и активность в зависимости от значения 
            if (i < maxCompleteLevel)            
                levelButton.SetImageColor(passedCol);            
            else if (i == maxCompleteLevel)
                levelButton.SetImageColor(currentCol);
            else
            {
                levelButton.SetImageColor(notOpenCol);
                button.GetComponent<Button>().interactable = false;
            }
        }
    }

}
