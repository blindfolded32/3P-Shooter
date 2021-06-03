using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public Button StartButton;
    public Button VolumeButton;
    public Button InfoButton;
    public Button QuitButton;

    public GameObject InfoPanel;
    public GameObject VolumeSettingsPanel;


    private void Start()
    {
        StartButton.onClick.AddListener(StartGame);
        VolumeButton.onClick.AddListener(VolumeChanger);
        InfoButton.onClick.AddListener(ShowInfo);
        QuitButton.onClick.AddListener(QuitGame);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void VolumeChanger()
    {
       InfoPanel.SetActive(false);
       VolumeSettingsPanel.SetActive(true);
    }

    public void QuitGame()
    {
        print("HERE");
        Application.Quit();
    }

    public void ShowInfo()
    {
        VolumeSettingsPanel.SetActive(false);
        InfoPanel.SetActive(true);
    }

}
