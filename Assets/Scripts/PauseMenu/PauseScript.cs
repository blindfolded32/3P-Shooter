using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Button ContinueButton;
    public Button SettinsButton;
    public Button QuitButton;

    public GameObject SettingsPanel;
    public GameObject MenuPanel;
    public GameObject PauseMenu;


    private void Start()
    {
        ContinueButton.onClick.AddListener(Continue);
        SettinsButton.onClick.AddListener(OpenSettings);
        QuitButton.onClick.AddListener(ExitGame);
    }
    public void Continue()
    {
        PauseMenu.SetActive(false);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().Stop(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        MenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }
}
