using Base;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button SettingsButton;
    public Button PlayButton;
    public Button ExitButton;

    private void Start()
    {
        SettingsButton.onClick.AddListener(OpenSettings);
        ExitButton.onClick.AddListener(ExitGame);
    }

    private void OpenSettings()
    {
        Debug.Log("OpenSettings");
    }
    private void ExitGame()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
    
}

