using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PageScript : MonoBehaviour
{
    private int level;

    [SerializeField] private InitialController initialController;
    [SerializeField] private MenuData menuData;
    //
    [SerializeField] private Button leftButton;
    [SerializeField] private Button rightButton;
    [SerializeField] private Button backButton;
    //
    [SerializeField] private int totalPages;
    [SerializeField] private int localPage;
    //
    [SerializeField] private GameObject GalleryScreen;
    //
    [SerializeField] private Button[] Pictures;
    [SerializeField] private TMP_Text[] PictureTexts;
    //
    [SerializeField] private Texture2D[] PicturePrefabs;
    [SerializeField] private Texture2D PictureStandartPrefab;
    //
    [SerializeField] private TMP_Text leftPageText;
    [SerializeField] private TMP_Text rightPageText;

    

    private void Start() 
    {
        leftButton.onClick.AddListener(LeftButton);
        rightButton.onClick.AddListener(RightButton);
        backButton.onClick.AddListener(BackButton);

        level = menuData.level + 1;
        totalPages = (int)Math.Ceiling((float)level / 8);
        localPage = 1;

        UpdatePage();

        leftButton.gameObject.SetActive(false);
        if (localPage>=totalPages)
        {
            rightButton.gameObject.SetActive(false);
        }

    }

    private void LeftButton()
    {
        Click();
        
        if (localPage>1)
        {
            localPage-=1;
        }
        
        if (localPage<=1)
        {
            leftButton.gameObject.SetActive(false);
        }

        rightButton.gameObject.SetActive(true);

        UpdatePage();
    }

    private void RightButton()
    {
        Click();
        
        if (localPage<totalPages)
        {
            localPage++;
        }
        
        if(localPage>= totalPages)
        {
            rightButton.gameObject.SetActive(false);
        }

        leftButton.gameObject.SetActive(true);

        UpdatePage();
    }

    private void UpdatePage()
    {
        leftPageText.text = (localPage*2-1).ToString();
        rightPageText.text = (localPage*2).ToString();

        for (int i = 0; i < Pictures.Length ; i++)
        {
            int PageIndex = (8*(localPage-1)+i+1);
            Pictures[i].gameObject.SetActive(PageIndex < level);
            //Pictures[i].image.sprite = Sprite.Create(PicturePrefabs[i], new Rect(0, 0, PicturePrefabs[i].width, PicturePrefabs[i].height), new Vector2(0.5f, 0.5f)); //КОД СТЕРЕТЬ ПРИ НАЛИЧИИ ПРЕФАБОВ ФОТОГРАФИЙ
            
            PictureTexts[i].text = PageIndex.ToString();
        }
    }

    
    private void BackButton()
    {
        Click();
        GalleryScreen.SetActive(false);
    }

    private void Click()
    {
        initialController.soundManager.PlaySound(Sound.Click);
    }
}
