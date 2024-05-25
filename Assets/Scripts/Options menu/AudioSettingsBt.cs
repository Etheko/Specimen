using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsBt : MonoBehaviour
{
    private Button button;

    public GameObject audioSettingsWindow;
    public GameObject mainSettingsWindow;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(audioMenu);
        
    }

    private void audioMenu()
    {
        AudioSystemManager.instance.PlayEffect("sfxAction");
        AudioSystemManager.instance.disableFilter();
        audioSettingsWindow.SetActive(true);
        mainSettingsWindow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
