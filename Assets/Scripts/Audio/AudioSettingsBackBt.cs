using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsBackBt : MonoBehaviour
{
    private Button button;
    public GameObject previousWindow;
    public GameObject currentWindow;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Back);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Back()
    {
        //disable OptionsMenuWindow parent object and enable MainMenuWindow
        AudioSystemManager.instance.PlayEffect("sfxCancel");
        AudioSystemManager.instance.enableFilter();
        currentWindow.SetActive(false);
        previousWindow.SetActive(true);
    }
}
