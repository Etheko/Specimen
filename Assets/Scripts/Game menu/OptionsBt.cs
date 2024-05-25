using UnityEngine;
using UnityEngine.UI;

public class OptionsBt : MonoBehaviour
{

    private Button button;
    public GameObject MainMenuWindow;
    public GameObject OptionsMenuWindow;


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Options);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Options()
    {
        AudioSystemManager.instance.PlayEffect("sfxAction");
        //disable MainMenuWindow parent object and enable OptionsMenuWindow
        MainMenuWindow.SetActive(false);
        OptionsMenuWindow.SetActive(true);
    }
}
