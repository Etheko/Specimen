using UnityEngine;

public class Opening : MonoBehaviour
{
    public GameObject dialog;

    public GameObject backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get user input
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Load the next dialog
            if (!dialog.GetComponent<TextCompletionEffectDialogs>().nextDialog())
            {
                // Load the game scene
                backgroundMusic.GetComponent<AudioManager>().FadeOut();
                UnityEngine.SceneManagement.SceneManager.LoadScene(3);
            }

        }

    }
}
