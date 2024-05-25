using UnityEngine;
using UnityEngine.UI;

public class ScreenModeBt : MonoBehaviour
{

    private Button button;

    public GameObject buttonText;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ScreenMode);

        // Check if the game is in fullscreen mode
        if (Screen.fullScreen)
        {

            buttonText.GetComponent<TMPro.TextMeshProUGUI>().text = "screenModeFullscreen";
            buttonText.GetComponent<TranslatableText>().initialize();
        }
        else
        {
            buttonText.GetComponent<TMPro.TextMeshProUGUI>().text = "screenModeWindow";
            buttonText.GetComponent<TranslatableText>().initialize();

        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ScreenMode()
    {
        AudioSystemManager.instance.PlayEffect("sfxAction");
        //change screen mode
        if (Screen.fullScreen)
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, false);

            buttonText.GetComponent<TMPro.TextMeshProUGUI>().text = "screenModeWindow";
            buttonText.GetComponent<TranslatableText>().initialize();
        }
        else
        {
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true); //set to fullscreen

            buttonText.GetComponent<TMPro.TextMeshProUGUI>().text = "screenModeFullscreen";
            buttonText.GetComponent<TranslatableText>().initialize();
        }
    }
}
