using Base;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private InitialController initialController;
    [SerializeField] private Button playButton;
    [SerializeField] private Button settingsButton;
    [SerializeField] private Button galleryButton;
    [SerializeField] private Button informationButton;
    [SerializeField] private Button exitButton;

    [SerializeField] private GameObject GalleryScreen;

    private void Start()
    {
        playButton.onClick.AddListener(PlayButton);
        settingsButton.onClick.AddListener(SettingsButton);
        galleryButton.onClick.AddListener(GalleryButton);
        informationButton.onClick.AddListener(InformationButton);
        exitButton.onClick.AddListener(ExitButton);
    }
    private void PlayButton()
    {
        
    }
    private void SettingsButton()
    {
        Click();
    }
    private void GalleryButton()
    {
        Click();
        GalleryScreen.SetActive(true);
    }
    private void InformationButton()
    {
        Click();
    }
    private void ExitButton()
    {
    
    }

    private void Quit()
    {
        Application.Quit();
    }

    private void Click()
    {
        initialController.soundManager.PlaySound(Sound.Click);
    }
    
}

