using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackBt : MonoBehaviour
{

    private Button button;
    public GameObject MainMenuWindow;
    public GameObject OptionsMenuWindow;

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
        OptionsMenuWindow.SetActive(false);
        MainMenuWindow.SetActive(true);
    }
}
