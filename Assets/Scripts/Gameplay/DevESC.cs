using System.Collections;
using UnityEngine;

public class DevESC : Wizard
{

    // Update is called once per frame
    void Update()
    {
        // if ESC is pressed, load the main menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }


        // if ENTER is pressed, create a text file
        if (Input.GetKeyDown(KeyCode.Return))
        {
            StartCoroutine(CreateTextFileCoroutine());
        }
    }

    IEnumerator ShowDialogCoroutine()
    {
        ShowDialog(":)", "You know what this means... :3");
        yield return null;
    }

    IEnumerator CreateTextFileCoroutine()
    {
        CreateTextFile("Just a file.txt", "???????????????????????????????");
        ShowDialog("???", "Check your desktop!");
        yield return null;
    }

}
