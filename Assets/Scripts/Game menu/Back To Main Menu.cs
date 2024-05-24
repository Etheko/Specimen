using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour
{
    private Button button;

    public GameObject gameMenuWindow;

    public GameObject inGameUI;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Back);
        
    }

    void Back()
    {
        //disable gameMenuWindow parent object
        gameMenuWindow.SetActive(false);
        Time.timeScale = 1;
        inGameUI.GetComponent<DevESC>().enablePlayerMovement();
        SceneManager.LoadScene(1);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
