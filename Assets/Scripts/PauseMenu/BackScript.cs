using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackScript : MonoBehaviour
{
    public GameObject SettingsPanel;
    public GameObject MenuPanel;

    public Button BackButton;

    // Start is called before the first frame update
    void Start()
    {
        BackButton.onClick.AddListener(GetBack);

    }

    void GetBack()
    {
        SettingsPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }
}
