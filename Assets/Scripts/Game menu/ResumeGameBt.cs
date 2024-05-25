using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResumeGameBt : MonoBehaviour
{

    private Button button;
    public GameObject gameMenuWindow;
    public GameObject gameMenuObject;


    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ResumeGame);
        
    }

    void ResumeGame()
    {
        AudioSystemManager.instance.PlayEffect("sfxAction");
        //disable gameMenuWindow parent object
        AudioSystemManager.instance.disableFilter();
        gameMenuWindow.SetActive(false);
        Time.timeScale = 1;
        gameMenuObject.GetComponent<DevESC>().enablePlayerMovement();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
