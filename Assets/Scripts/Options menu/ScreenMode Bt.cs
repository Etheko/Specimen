using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenModeBt : MonoBehaviour
{

    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ScreenMode);

        // Check if the game is in fullscreen mode
        if (Screen.fullScreen)
        {
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Mode: Fullscreen";
        }
        else
        {
            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Mode: Windowed";
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ScreenMode()
    {
        //change screen mode
        if (Screen.fullScreen)
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, false);

            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Mode: Windowed";
        }
        else
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true); //set to fullscreen

            button.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Mode: Fullscreen";
        }
    }
}
