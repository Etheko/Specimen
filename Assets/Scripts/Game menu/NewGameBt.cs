using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class NewGameBt1 : MonoBehaviour
{
    private Button button;
    private GameObject audioSourceObject;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(NewGame);
    }

    void Update()
    {

    }

    void NewGame()
    {
        InventoryManager.instance.resetInventory();
        AudioSystemManager.instance.PlayEffect("sfxAction");
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);

    }
}