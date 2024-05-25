using UnityEngine;
using UnityEngine.UI;

public class BackBt : MonoBehaviour
{

    private Button button;
    public GameObject previousWindow;
    public GameObject currentWindow;
    public bool confirmSound = false;

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
        if (confirmSound)
        {
            AudioSystemManager.instance.PlayEffect("sfxAction");
        } else
        {
            AudioSystemManager.instance.PlayEffect("sfxCancel");
        }
        currentWindow.SetActive(false);
        previousWindow.SetActive(true);
    }
}
