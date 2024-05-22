using UnityEngine;

public class Opening : MonoBehaviour
{
    public GameObject dialog;

    public GameObject backgroundMusic;

    public VectorValue playerStorage;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get user input
        if (dialog.GetComponent<TextCompletionEffectDialogs>().isDialogDone())
        {

            // Load the game scene
            backgroundMusic.GetComponent<AudioManager>().FadeOut();
            playerStorage.initialValue = new Vector2(0, 0);
            playerStorage.playerDirection = new Vector2(0, -1);
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);

        }

    }
}
