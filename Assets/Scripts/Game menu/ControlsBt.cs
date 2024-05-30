using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlsBt : MonoBehaviour
{
    private Button button;
    public GameObject MainMenuWindow;
    public GameObject ControlsWindow;


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Controls);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Controls()
    {
        AudioSystemManager.instance.PlayEffect("sfxAction");
        //disable MainMenuWindow parent object and enable OptionsMenuWindow
        MainMenuWindow.SetActive(false);
        ControlsWindow.SetActive(true);
    }
}
