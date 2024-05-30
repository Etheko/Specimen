using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueBt : MonoBehaviour
{
    private Button button;
    private GameObject audioSourceObject;

    public VectorValue playerStorage;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ResumeGame);
    }

    void Update()
    {

    }

    void ResumeGame()
    {
        AudioSystemManager.instance.PlayEffect("sfxAction");
        // Load the game scene
        playerStorage.initialValue = new Vector2(0, 0);
        playerStorage.playerDirection = new Vector2(0, -1);
        UnityEngine.SceneManagement.SceneManager.LoadScene(3); // TODO: Change the scene number to the correct one (read PlayerPrefs)

    }
}
