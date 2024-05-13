using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevESC : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        // if ESC is pressed, load the main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
    }
}
